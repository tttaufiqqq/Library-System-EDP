# Fine Ledger + ToyyibPay FPX Payment

## What this is

A rework of the fine and payment flow, which previously had no persistence at
all: `Fine.cs` (staff) and `BorrowerFines.cs` (borrower) both ended in
`MessageBox.Show("Your payment is successful.")` with nothing written to the
database, and `FineCalculator.ComputeFine()` returned `0m` the moment a book's
`Return_Status` flipped to `"Returned"` — so returning a book late silently
erased the fine that was owed.

This file documents the target design. See
`Migrations/004_add_fines_and_payments.sql` for the schema and
`Services/FineService.cs` / `Services/FinePaymentService.cs` /
`Services/ToyyibPayService.cs` for the implementation.

## Decisions (confirmed with user)

1. **Payment is borrower-only.** The staff `Fine` panel used to be a card/cash
   entry form under the staff's own "Welcome, staffTaufiq!" banner — it read
   as staff paying someone else's fine, with no borrower identity or amount
   ever shown before Pay. That form is gone; the staff `Fine` panel is now a
   **read-only fines report**.
2. **No card fields anywhere.** Payment goes through **ToyyibPay sandbox FPX
   online banking** (`billPaymentChannel=0`), so the app never collects a
   card number, expiry, or CVC. This isn't just a UX choice — it removes an
   entire class of PCI-scope risk from a project that was never going to be
   PCI-compliant in the first place.
3. **A fine is finalized once, at return — not recomputed forever.**
   `FineCalculator.ComputeAccruing` still shows a live, non-payable estimate
   on "My Loans" while a book is overdue and not yet returned. The moment
   `IssueService.ReturnBook` confirms the return, `FineService.FinalizeOnReturn`
   freezes the amount into a `dbo.Fines` ledger row. A fine only becomes
   **payable** after this point.
4. **Fine cap: RM 50** (10 days at RM 5/day). Uncapped, a book returned months
   late would produce an implausibly large bill.
5. **Every payment attempt is its own row** (`dbo.FinePayments`), not a flag
   on the fine. A borrower can abandon a bill mid-checkout and retry; the
   ledger fine only flips `Unpaid -> Paid` once, in `FinePaymentService.Settle`.

## Why polling instead of a return URL

ToyyibPay's `createBill` requires `billReturnUrl` (browser redirect after
payment) and `billCallbackUrl` (server-to-server webhook). A WinForms desktop
app has **no web server** to receive either — so both are pointed at the
gateway's own domain (`https://dev.toyyibpay.com`) and are **never relied on
for anything**. The only source of truth for "did this bill get paid" is
`ToyyibPayService.GetBillStatus`, polled from `PaymentWaitDialog` on a
`System.Windows.Forms.Timer`. This also removes an entire class of bugs where
a forged redirect could claim success — there is no redirect to forge.

`GetBillStatus` fails closed: any HTTP error, timeout, or malformed response
returns `PaymentStatus.Unknown`, which the dialog treats identically to
`Pending` (keep waiting) — never as success.

## Status code mapping

ToyyibPay's `billpaymentStatus` (from `getBillTransactions`):

| Raw value | `PaymentStatus` | Dialog behavior |
|---|---|---|
| `"1"` | `Success` | Stop polling, `FinePaymentService.Settle`, close `DialogResult.OK` |
| `"2"` | `Pending` | Keep polling |
| `"3"` | `Failed` | Stop polling, `FinePaymentService.MarkFailed`, close `DialogResult.Abort` |
| anything else / exception | `Unknown` | Keep polling (fail closed) |

## Fine lifecycle

```
                        BOOK IS OVERDUE (not yet returned)
                                    |
                        FineCalculator.ComputeAccruing(issue)
                        = min(days_late x RM5, RM50)
                        display only on "My Loans" - NOT payable, NOT stored
                                    |
                                    v
                        STAFF CONFIRMS RETURN
                        IssueService.ReturnBook(issueId)
                                    |
                        +-----------+------------+
                        v                        v
            Actual_Return_Date = now     FineService.FinalizeOnReturn(issueId)
            Return_Status="Returned"     days_late = Actual_Return - Due
            Book -> Available            if days_late > 0:
                                           INSERT dbo.Fines
                                             Overdue_Days, Amount,
                                             Status = 'Unpaid'
                                         (idempotent: one fine per IssueID,
                                          backed by UX_Fines_IssueID)
                                    |
                                    v
                    BORROWER "MY FINES"  (BorrowerFines.cs)
                    grid reads dbo.Fines only
                    Total unpaid shown above the grid
                    [PAY ONLINE (FPX)] enabled only when the
                    selected row's Status == 'Unpaid'
```

## Payment round-trip

```
buttonPay_Click (BorrowerFines.Payment.cs)
  |  re-reads the fine by ID - never trusts the grid cell
  |  confirms book + exact amount with the borrower
  v
FinePaymentService.StartPayment(fineId)
  |  refuses if Status != 'Unpaid'
  |  reuses an existing Pending bill for this fine if one is open
  v
ToyyibPayService.CreateBill(...)
  POST https://dev.toyyibpay.com/index.php/api/createBill
  billAmount = ledger amount x 100 (SEN)
  billPaymentChannel = 0   (FPX online banking only)
  billReturnUrl / billCallbackUrl = the gateway's own domain (see above)
  |
  v
INSERT dbo.FinePayments (Bill_Code, Reference_No, Amount, Status='Pending')
  |
  v
Process.Start("https://dev.toyyibpay.com/{BillCode}")   opens default browser
  |
  v
PaymentWaitDialog (modal)
  Timer polls ToyyibPayService.GetBillStatus every 4s, capped at 5 minutes
  Cancel button available at any time
  |
  +--- Success -> FinePaymentService.Settle(billCode)
  |                 guard: payment/fine already settled? -> no-op
  |                 FinePayments.Status='Success', Fines.Status='Paid'
  |                 (single SubmitChanges)
  |
  +--- Failed  -> FinePaymentService.MarkFailed(billCode)
  |                 Fines row stays 'Unpaid', borrower may retry
  |
  +--- Cancel/timeout -> nothing changes; re-pressing Pay reuses the same bill
  |
  v
BorrowerFines.LoadFines refreshes; outstanding total updates;
BorrowingPolicy.Check (reads dbo.Fines.Status=='Unpaid') now passes
once every fine is settled.
```

## Data model

`Migrations/004_add_fines_and_payments.sql` adds:

```
IssuesBooks.Actual_Return_Date  DATETIME NULL
  -- the column that never existed; Return_Date holds the DUE date despite
  -- its name, so there was previously no way to know when a book actually
  -- came back.

dbo.Fines
  FineID          INT IDENTITY PK
  IssueID         VARCHAR(100) NOT NULL   -- logical link only, see below
  Email, Full_Name, Book_Title            -- denormalized at finalize time
  Overdue_Days    INT NOT NULL
  Amount          DECIMAL(10,2) NOT NULL  -- frozen once, never recomputed
  Assessed_Date   DATETIME NOT NULL
  Status          VARCHAR(20) NOT NULL DEFAULT 'Unpaid'
  Paid_Date       DATETIME NULL
  UNIQUE INDEX on IssueID   -- one fine per loan, ever; backs Finalize's idempotency

dbo.FinePayments
  PaymentID       INT IDENTITY PK
  FineID          INT NOT NULL REFERENCES dbo.Fines(FineID)
  Bill_Code       VARCHAR(100) NOT NULL
  Reference_No    VARCHAR(100) NOT NULL
  Amount          DECIMAL(10,2) NOT NULL
  Channel         VARCHAR(50) NOT NULL DEFAULT 'FPX Online Banking'
  Status          VARCHAR(20) NOT NULL DEFAULT 'Pending'
  Created_Date    DATETIME NOT NULL
  Completed_Date  DATETIME NULL
  UNIQUE INDEX on Bill_Code   -- the settlement idempotency key
```

`dbo.Fines.IssueID` has no real foreign key: `IssuesBooks`' primary key is
the identity column `ID`, and `IssueID` is a `VARCHAR(MAX)` business key
(`"ISS" + yyyyMMddHHmmssfff`). `VARCHAR(MAX)` columns cannot carry an index or
FK, so `dbo.Fines.IssueID` is declared `VARCHAR(100)` purely so the unique
index can exist — matching the same by-value-equality style the rest of this
schema already uses (`BookRequests` -> `Books`/`Users` has no FK either; see
`docs/borrower-self-request.md`).

## LINQ entity naming

The C# type mapped to `dbo.Fines` is named `FineRecord`, not `Fine` — the
existing staff panel is already `Library_Management_System_project.Fine`
(a `UserControl`), and a LINQ-to-SQL entity cannot share that name in the
same namespace. Renaming the UserControl instead would touch its designer
file, every reference to it in `MainForm`, and its resx for no functional
gain, so the entity was renamed instead (`FineRecord`, `FinePaymentRecord`).

## Configuration

`App.config` (gitignored, copy from `App.config.example`):

```xml
<add key="ToyyibPayBaseUrl" value="https://dev.toyyibpay.com" />
<add key="ToyyibPayCategoryCode" value="YOUR_SANDBOX_CATEGORY_CODE" />
<add key="ToyyibPaySecretKey" value="YOUR_SANDBOX_SECRET_KEY" />
```

To get sandbox credentials: register at `dev.toyyibpay.com`, create a
Category (the resulting Category Code goes in `ToyyibPayCategoryCode`), and
copy the User Secret Key from your profile settings into
`ToyyibPaySecretKey`. `ToyyibPayBaseUrl` must stay pointed at
`dev.toyyibpay.com` — never the production host — for this project.

## Implementation phases

| Phase | What | Key files |
|-------|------|-----------|
| 1 | Schema: migration + `FineRecord`/`FinePaymentRecord` entities | `Migrations/004_add_fines_and_payments.sql`, `Library.dbml`, `Library.designer.cs` |
| 2 | Fine domain logic: cap, finalize-on-return, policy | `Services/FineCalculator.cs`, `Services/FineService.cs` (new), `Services/IssueService.cs`, `Services/BorrowingPolicy.cs` |
| 3 | ToyyibPay sandbox gateway client | `Services/IPaymentGateway.cs`, `Services/PaymentStatus.cs`, `Services/BillRequest.cs`, `Services/ToyyibPayService.cs` (all new), `Program.cs` (TLS 1.2) |
| 4 | Borrower payment flow | `Services/FinePaymentService.cs` (new), `PaymentWaitDialog.cs/.Designer.cs` (new), `BorrowerFines.cs`, `BorrowerFines.Payment.cs` (new) |
| 5 | Staff read-only fines report | `Fine.cs`, `Fine.Designer.cs`, `MainForm.Designer.cs` (nav relabel) |
| 6 | Config + secret hygiene | `App.config`, `App.config.example` (new), `.gitignore` |
| 7 | Docs + verification | this file, manual end-to-end pass |

## Out of scope

- **No cash payment path.** Payment is online-only, borrower-initiated; there
  is no in-person cash-collection screen for staff.
- **No partial payments or waivers.** A fine is paid in full via one
  successful bill, or not at all.
- **No lost-book / replacement-cost charge** distinct from the daily late
  fee — a book that is never returned only ever accrues the capped RM 50
  estimate on "My Loans" and never becomes a ledger fine (finalization only
  happens at return).
- **No server-side permission enforcement**, same accepted limitation as the
  rest of the app.

## Migration / data notes

Requires `Migrations/004_add_fines_and_payments.sql`, applied the same way as
`001`-`003` — run manually against the SQL Server instance; not auto-applied
by the app. Existing rows with `Return_Status = 'Returned'` from before this
change have no `Actual_Return_Date` and no ledger row — those historical late
returns are unrecoverable, since the data needed to reconstruct them
(when the book actually came back) was never captured. The ledger only
accumulates from the first return confirmed after this migration is applied.
