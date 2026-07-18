# Borrower Self-Request from Browse Catalog

## What this is

A follow-up to [role-permissions-and-dashboards.md](role-permissions-and-dashboards.md),
which gave Borrowers a read-only catalog browser. This change lets a Borrower
act on that catalog: select an Available book and submit a request; a Staff
member approves or rejects it. Approval creates a real loan through the
existing issue pipeline and marks the book Issued.

This file documents the **target design**. Implementation proceeds in five
phases (see Phases below); check the plan file for live checklist state:
`C:\Users\taufi\.claude\plans\plan-again-elegant-clover.md`

## Decisions (confirmed with user)

1. **Request -> Staff approves**, not immediate self-checkout. A borrower
   creates a *pending request*; a Staff member approves or rejects it.
2. **Requests live in a new `BookRequests` table**, not in `IssuesBooks`.
   Overloading `IssuesBooks.Return_Status` with a third value `"Requested"`
   would leak into `IssueService.GetActiveIssues()` (Return Books would offer
   to "return" a book never actually issued), the Staff `IssuedBooks` grid,
   and `FineCalculator` (would fine a loan that never started). A separate
   table keeps all four of those working Staff features untouched.
3. **Contact number is prompted in the request dialog.** The `User` entity
   has no phone column, but `IssuesBooks.Contact` is required for a loan.
4. **Guardrails enforced at request time**: block a duplicate active
   loan/request for the same book, block if the borrower has unpaid fines,
   cap concurrent loans+requests per borrower, and mark the book unavailable
   only **on approval** (not on request) — so two borrowers may request the
   same available title; the second approval attempt auto-rejects with
   "book no longer available".
5. **Approval queue is Staff-only**, a new panel on `MainForm`. Hidden on
   `AdminMainForm`, consistent with Admin being de-supersetted from
   front-desk operations (see role-permissions-and-dashboards.md).

## Status lifecycle

```
[borrower submits]           [staff]
      |                    Approve / Reject
      v                        |
   Pending  --------------------+------------------> Approved  (loan created, book Issued)
                                |
                                +------------------> Rejected  (no side effects)
```

Approve re-checks the book is still `Available` (Staff may have direct-issued
it, or a competing request was approved first). If not, the request is
auto-rejected with reason "book no longer available" instead of failing.

## End-to-end form flow

```
BORROWER SIDE                                  STAFF SIDE
-------------                                  ----------
BorrowerForm
  |  click "Browse Catalog"
  v
BorrowerCatalog  (search + grid + [Request])
  |  select an Available book, click Request
  v
RequestBookDialog (modal)
  | Contact + Return Date, Confirm
  v
BorrowingPolicy.Check(...)  --fail--> MessageBox (reason), stay
  | pass
  v
RequestService.CreateRequest  ->  BookRequests row (Status=Pending)
  |
  v
"Request submitted, pending staff approval"
                                               MainForm
                                                 |  click "Book Requests"
                                                 v
                                               BookRequestsPanel (grid of Pending)
                                                 |  select row
                                                 +--> [Approve] --> RequestService.Approve
                                                 |        - re-check book Available
                                                 |        - IssueService.IssueBook(new loan)
                                                 |        - BookService.SetBookStatus(Issued)
                                                 |        - Status=Approved, Decided_By/Date
                                                 |        loan now shows in Staff Issued Books
                                                 |        and in Borrower "My Loans"
                                                 +--> [Reject]  --> Status=Rejected
```

## Wireframes

BorrowerCatalog (modified — Request button added to the search bar):

```
+-----------------------------------------------------------------+
|  Search: [ hobbit                    ]     [ Request Book ]      |
+-----------------------------------------------------------------+
| Book_Title      | Author        | Book_Status | Published_Date  |
|-----------------+---------------+-------------+-----------------|
| The Hobbit      | J.R.R.Tolkien | Available   | 1937-09-21      | <- selectable rows
| Dune            | F. Herbert    | Issued      | 1965-08-01      |
| 1984            | G. Orwell     | Available   | 1949-06-08      |
+-----------------------------------------------------------------+
```

Request enabled only when the selected row's `Book_Status == "Available"`.

RequestBookDialog (new modal):

```
+----------- Request Book -----------------+
|                                          |
|  Book:     The Hobbit        (read-only) |
|  Author:   J.R.R. Tolkien    (read-only) |
|                                          |
|  Contact:  [ 0123456789            ]     |
|  Return by:[ 2026-08-01        v ]       |  <- default today + 14 days
|                                          |
|            [ Confirm ]   [ Cancel ]      |
+------------------------------------------+
```

Validation: `InputValidator.IsValidPhone(Contact)`; return date must be in
the future.

BookRequestsPanel (new, Staff `MainForm` only):

```
+-----------------------------------------------------------------+
|  Pending Book Requests                     [ Refresh ]          |
+-----------------------------------------------------------------+
| Req# | Borrower     | Book        | Contact    | Requested  | Due|
|------+--------------+-------------+------------+------------+----|
| 12   | Alice (email)| The Hobbit  | 0123456789 | 2026-07-18 |... | <- select
| 13   | Bob   (email)| 1984        | 0198887777 | 2026-07-18 |... |
+-----------------------------------------------------------------+
|                        [ Approve ]   [ Reject ]                  |
+-----------------------------------------------------------------+
```

Status strip echoes the result, e.g. "Request 12 approved - loan
ISS20260718...".

Sidebar placement:

```
Staff MainForm sidebar          Admin (AdminMainForm) sidebar
----------------------          -----------------------------
Dashboard                       Dashboard
Add Books                       Add Books
Issue Books                     Manage Users
Return Books                    (Issue/Return/Fine hidden)
Fine                            (Book Requests hidden)
Book Requests   <-- NEW
```

## Data model

New table `dbo.BookRequests`:

```
RequestID       INT IDENTITY PK
Email           VARCHAR(MAX)     -- borrower identity (from User.email)
Full_Name       VARCHAR(MAX)     -- from User.username
Contact         VARCHAR(MAX)     -- prompted in dialog
BookID          INT              -- FK-by-value to Books.BookID
Book_Title      VARCHAR(MAX)
Author          VARCHAR(MAX)
Requested_Date  DATE
Return_Date     DATE             -- borrower-chosen due date
Status          VARCHAR(20) NOT NULL DEFAULT 'Pending'   -- Pending/Approved/Rejected
Decided_Date    DATE NULL
Decided_By      VARCHAR(MAX) NULL -- staff username
```

Mapped as entity `BookRequest` (Member `BookRequests`) mirroring the
`IssuesBook` mapping style in `Library.dbml` / `Library.designer.cs`. No
foreign key constraints are added (matches the existing schema's style —
`IssuesBooks` also links to `Books`/`Users` only by value equality, not FK).

## Guardrails (`Services/BorrowingPolicy.cs`)

Checked in order at request time:

1. Book `Book_Status == "Available"` — else "This book is not available".
2. No duplicate: no active `IssuesBooks` row (`Return_Status == "Not
   Returned"`, same Email+Book_Title) and no `Pending` `BookRequests` row
   (same Email+BookID).
3. No unpaid fines: sum of `FineCalculator.ComputeFine` over the borrower's
   active issues must be zero.
4. Concurrent cap: `(active loans + pending requests)` for the borrower must
   be under `MaxConcurrentLoans` (const = 5).

## Implementation phases

| Phase | What | Key files |
|-------|------|-----------|
| 1 | Schema: migration + `BookRequest` entity | `Migrations/002_add_book_requests.sql`, `Library.dbml`, `Library.designer.cs` |
| 2 | Services: policy + request lifecycle | `Services/BorrowingPolicy.cs` (new), `Services/RequestService.cs` (new), `Services/IssueService.cs` (+`GenerateIssueId`), `Services/BookService.cs` (+`SetBookStatus`) |
| 3 | Borrower UI: request dialog + catalog button | `RequestBookDialog.cs/.Designer.cs` (new), `BorrowerCatalog.cs/.Designer.cs`, `BorrowerForm.cs` |
| 4 | Staff UI: approval queue | `BookRequestsPanel.cs/.Designer.cs` (new), `MainForm.cs/.Designer.cs`, `AdminMainForm.cs` |
| 5 | Verification: build + manual pass per role | n/a |

## Why (rationale)

Borrowers previously had no way to act on the catalog they could browse —
every loan required a Staff member to key it into `IssuedBooks` manually,
even for a book the borrower had already picked out. Routing self-requests
through an approval step (rather than instant self-checkout) keeps a human
in the loop for a physical-media library, matches how the existing
front-desk flow already works (Staff types up the loan), and avoids trusting
an unauthenticated write path to directly mutate book availability. Using a
separate `BookRequests` table rather than repurposing `IssuesBooks.Return_
Status` is what keeps this a genuinely surgical change — the four existing
Staff features that already read `Return_Status` (`GetActiveIssues`, the
Issued Books grid, `FineCalculator`, dashboard counts) require zero code
changes.

## Out of scope

- **No FK constraints** between `BookRequests` and `Books`/`Users` — matches
  the existing schema's by-value-equality style (see role-permissions doc).
- **No request expiry/timeout.** A `Pending` request with no staff action
  stays pending indefinitely; there is no scheduled job to auto-expire it.
- **No borrower-side cancel.** Once submitted, a borrower cannot withdraw a
  pending request from the UI; only Staff can Approve/Reject. (Could be a
  follow-up if needed.)
- **No email/push notification** to the borrower when a request is decided;
  they discover the outcome by checking "My Loans" or re-browsing the
  catalog.
- **No server-side permission enforcement**, same accepted limitation as the
  rest of the app (UI-level gating only, no service-layer role checks).

## Migration / data notes

Requires one new migration: `Migrations/002_add_book_requests.sql`, applied
the same way as `001_add_user_role.sql` — the user runs it against the
homelab SQL server manually; it is not auto-applied by the app.

Existing seed accounts for manual verification: `adminTaufiq` (Admin),
`staffTaufiq` (Staff). A Borrower account is created by registering through
`RegisterForm`.
