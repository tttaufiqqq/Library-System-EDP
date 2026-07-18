# Role Permissions & Per-Role Dashboards

## What this is

A follow-up to [role-based-multi-user-forms.md](role-based-multi-user-forms.md).
That earlier change introduced the Admin/Staff/Borrower roles and routed each
to its own landing form, but `AdminMainForm` was a strict superset of
`MainForm` (Admin could do every Staff task plus user management). This
change makes Admin a genuinely distinct, management-focused role, splits
catalog-delete authority from catalog-edit, gives Admin an analytics
dashboard with charts, and gives Borrowers a read-only catalog browser and a
"my fines" view.

This file documents the **target design**. Implementation proceeds in six
phases (see Phases below); check the plan file for live checklist state:
`C:\Users\taufi\.claude\plans\c-users-taufi-documents-dev-plan-format-memoized-unicorn.md`

## Role decisions (confirmed with user)

1. **Admin is management-focused, not a Staff superset.** Admin drops
   Issue Books / Return Books / Fine collection entirely.
2. **Borrower gains two new views**: read-only catalog browse, and a "my
   fines" view (view + pay, pay is currently a mock — see Out of scope).
3. **Catalog CRUD is split**: Staff can add/edit; only Admin can delete
   (soft delete via `Bookk.Date_Delete`).
4. **Fine collection/waiving is Staff-only.** Admin does not touch fines.

## Role capability matrix

```
Capability                              | Admin | Staff | Borrower
----------------------------------------+-------+-------+---------
View Dashboard KPI tiles                |   Y   |   Y   |    -
View analytics CHARTS                   |   Y   |   -   |    -
Book catalog: add / edit                |   Y   |   Y   |    -
Book catalog: DELETE (soft)             |   Y   |   -   |    -
Browse / search catalog (read-only)     |  via  |  via  |    Y
                                        | editor| editor|
Issue books                             |   -   |   Y   |    -
Return books                            |   -   |   Y   |    -
Fine collect / waive (counter)          |   -   |   Y   |    -
Manage users (roles, delete user)       |   Y   |   -   |    -
View own loans                          |   -   |   -   |    Y
View / pay OWN fines                    |   -   |   -   |    Y
```

- **Admin** — system administration and oversight. Lands on `AdminMainForm`.
  Owns catalog authority (add/edit/delete) and user management, plus
  analytics. Does NOT do front-desk operations (issue/return/fine).
- **Staff** — daily front-desk operations. Lands on `MainForm`. Add/edit
  catalog (no delete), issue, return, and handle fines. No user management,
  no charts.
- **Borrower** — self-service. Lands on `BorrowerForm`. Sees own loans,
  browses catalog read-only, views/pays own fines. Sees no other user's data.

## Flow diagrams

### Global entry flow (all roles)

```
        +-----------------+
        |  StartUpScreen  |
        +-----------------+
                 |
                 v
        +-----------------+          signup          +----------------+
        |    LoginForm    | -----------------------> |  RegisterForm  |
        |                 | <----------------------- | (creates       |
        +-----------------+     back after signup    |  Borrower)     |
             |   ^                                    +----------------+
        auth |   | invalid -> error, stay on LoginForm
             v   |
     role switch (LoginForm.cs:70-89, user.role)
     /-----------|-----------\
     v           v            v
  [Admin]     [Staff]     [Borrower]
     |            |            |
     v            v            v
AdminMainForm  MainForm   BorrowerForm
```

### Admin flow (management-focused)

```
                          +-------------------+
                          |   AdminMainForm   |
                          | (top bar + sidebar|
                          |  + content host)  |
                          +-------------------+
                                    |
      +----------------+------------+-----------+----------------+
      |                |                        |                |
      v                v                        v                v
+-------------+  +--------------+        +--------------+  +-------------+
|  Dashboard  |  | Book Catalog |        | Manage Users |  |   Log Out   |
| KPI tiles + |  | (AddBooks)   |        | (ManageUsers)|  | -> LoginForm|
|  CHARTS     |  | add / edit / |        | change role, |  +-------------+
| (Admin only)|  | DELETE (on)  |        | delete user  |
+-------------+  +--------------+        +--------------+
   (Issue / Return / Fine buttons are HIDDEN for Admin)
```

### Staff flow (front-desk operations)

```
                             +----------------+
                             |    MainForm    |
                             | (top bar +     |
                             |  sidebar+host) |
                             +----------------+
                                     |
   +----------+----------+-----------+-----------+----------+----------+
   |          |          |           |           |          |          |
   v          v          v           v           v          v          v
+--------+ +--------+ +--------+  +---------+  +--------+ +--------+ (no
|Dashbrd | |Book    | | Issue  |  | Return  |  | Fines  | |Log Out | Manage
|KPI tile| |Catalog | | Books  |  | Books   |  |collect | |->Login | Users,
|(no     | |add/edit| |(Issued |  |(Return  |  |/ waive | +--------+ no
| chart) | |NO del  | | Books) |  | Books)  |  |(Fine)  |           charts)
+--------+ +--------+ +--------+  +---------+  +--------+
```

### Borrower flow (self-service)

```
                        +-----------------+
                        |  BorrowerForm   |
                        | (top bar + nav  |
                        |  + content host)|
                        +-----------------+
                                 |
      +----------------+---------+---------+------------------+
      |                |                   |                  |
      v                v                   v                  v
+-------------+  +--------------+   +--------------+   +-------------+
|  My Loans   |  |   Browse     |   |  My Fines    |   |   Log Out   |
| (existing   |  |   Catalog    |   | (own fines,  |   | -> LoginForm|
|  loans grid)|  | (read-only,  |   |  view + pay) |   +-------------+
+-------------+  |  search)     |   +--------------+
                 +--------------+
```

## Form layout wireframes

Shared MainForm / AdminMainForm shell (`panel1` top bar, `panel2` sidebar,
`panel3` content host — see `MainForm.Designer.cs`):

```
+-----------------------------------------------------------------------+
| panel1 (top bar)     Welcome, <username>!                       [ X ] |
+------------------+----------------------------------------------------+
| panel2 (sidebar) | panel3 (content host)                              |
|                  |                                                     |
|  STAFF sidebar   |    < active UserControl rendered here >            |
|  [ DASHBOARD  ]  |                                                     |
|  [ BOOK CATALOG] |                                                     |
|  [ ISSUE BOOKS ] |                                                     |
|  [ RETURN BOOKS] |                                                     |
|  [ FINES      ]  |                                                     |
|  [ LOG OUT    ]  |                                                     |
+------------------+----------------------------------------------------+

  ADMIN sidebar (Issue/Return/Fine removed, buttons re-stacked, no gaps):
  [ DASHBOARD    ]   y=174 (unchanged)
  [ BOOK CATALOG ]   y=206 (unchanged, relabeled from "ADD BOOKS")
  [ MANAGE USERS ]   y=238 (moved up from y=347, fills old Issue Books slot)
  [ LOG OUT      ]   y=270 (moved up from y=394, fills old Return Books slot)
```

Dashboard — Admin view (KPI tiles kept, charts section added below):

```
+-----------------------------------------------------------------------+
| KPI TILES                                                             |
| +-----------+ +-----------+ +-----------+ +-----------+               |
| | Available | |  Issued   | | Returned  | |  Users    |               |
| |    123    | |    45     | |    67     | |    89     |               |
| +-----------+ +-----------+ +-----------+ +-----------+               |
+-----------------------------------------------------------------------+
| CHARTS (visible only in AdminMainForm)                               |
| +-----------------------------+ +-----------------------------+       |
| | Books by Status  (Pie)      | | Users by Role   (Doughnut)  |       |
| |        .-''-.                | |        .-''-.                |      |
| |       / A | I \              | |       /Adm|Sta\              |      |
| |       \  |R  /               | |       \ Borr /               |      |
| |        '-..-'                | |        '-..-'                |      |
| +-----------------------------+ +-----------------------------+       |
| +-----------------------------+ +-----------------------------+       |
| | Issues over time (Column)   | | Top borrowed books (Bar)    |       |
| |  #     #                     | | ####### Title A             |       |
| |  #  #  #  #                   | | #####   Title B             |      |
| |  #  #  #  #  #                 | | ###     Title C            |      |
| +-----------------------------+ +-----------------------------+       |
+-----------------------------------------------------------------------+
```

Dashboard — Staff view = same KPI tiles, charts section hidden
(`Dashboard.SetChartsVisible(false)`, the default).

Book Catalog (`AddBooks`) — Admin shows Delete; Staff hides Delete:

```
+-----------------------------------------------------------------------+
| Search: [____________________]                                        |
| +------------------------+   +------------------------------------+    |
| | [ Book Cover Image  ]  |   | dataGridView (books list)          |    |
| | [ Import ]             |   |  Title | Author | Status | Dates    |   |
| | Title:   [__________]  |   |  ...                                |   |
| | Author:  [__________]  |   |  ...                                |   |
| | Pub Date:[  v ]        |   |                                     |   |
| | Status:  [  v ]        |   |                                     |   |
| +------------------------+   +------------------------------------+    |
|                                                                       |
|  Admin:  [ Add ] [ Update ] [ Delete ] [ Clear ]                      |
|  Staff:  [ Add ] [ Update ] [ Clear ]        (Delete hidden)          |
+-----------------------------------------------------------------------+
```

Manage Users (Admin only) — unchanged, shown for completeness:

```
+-----------------------------------------------------------------------+
| dataGridView (userId | username | email | role | date_register)       |
| +-------------------------------------------------------------------+ |
| Username: [__________]  Email: [__________]  Role: [ v ]              |
| [ Apply Role ]   [ Delete User ]                                       |
+-----------------------------------------------------------------------+
```

Borrower shell (nav + content host) with My Loans / Browse Catalog / My Fines:

```
+-----------------------------------------------------------------------+
| panel1 (top bar)   Welcome, <username>!                         [ X ] |
+------------------+----------------------------------------------------+
| nav              | content host                                       |
| [ MY LOANS    ]  |  My Loans:  grid(Title|Author|Issue|Due|Status|Fine)|
| [ BROWSE CAT. ]  |  Browse:    search + read-only grid(Title|Author|   |
| [ MY FINES    ]  |             Status)                                 |
| [ LOG OUT     ]  |  My Fines:  grid(Title|Due|OverdueDays|Fine) [Pay]  |
+------------------+----------------------------------------------------+
```

## Implementation phases

| Phase | What | Key files |
|-------|------|-----------|
| 1 | De-superset Admin: hide Issue/Return/Fine buttons+panels for Admin, restack sidebar | `MainForm.Designer.cs`, `AdminMainForm.cs`, `AdminMainForm.Designer.cs` |
| 2 | Catalog delete gating: `AddBooks.SetCanDelete(bool)` | `AddBooks.cs`, `MainForm.cs`, `AdminMainForm.cs` |
| 3 | Admin dashboard charts (4 charts, `System.Windows.Forms.DataVisualization`) | `Dashboard.Charts.cs` (new partial), `Dashboard.Designer.cs`, `Services/DashboardService.cs` |
| 4 | Borrower browse catalog (read-only, reuses `AddBooks.DisplayBooks` search pattern) | new `BorrowerCatalog` UserControl, `BorrowerForm.cs/.Designer.cs` |
| 5 | Borrower my fines (view + mock pay) | new `BorrowerFines` UserControl, `BorrowerForm.cs/.Designer.cs` |
| 6 | Verification: manual pass per role, file-length check, build | n/a |

## Why (rationale)

Admin being a strict Staff superset meant there was no real separation of
duties — an administrator account could also perform every front-desk
action, which defeats the point of having roles at all. Splitting
catalog-delete from catalog-edit follows the same principle: edit is routine
work (Staff), delete is a destructive/administrative action (Admin only).
Borrowers previously had no way to discover what's in the catalog before
asking Staff to issue a book, and no way to see fine amounts framed as
"my fines" rather than inline table columns — both are pure read additions
that don't touch the write paths Staff/Admin own.

## Out of scope

- **Fine persistence.** `Fine.cs` is a UI mock — `buttonPay_Click` shows a
  success `MessageBox` but writes nothing to the database; there is no
  fines table or `FineService`. The Borrower "My Fines" pay action and
  Staff's existing Payment panel both remain mock behavior. Real fine
  persistence (a `Fines` table, waive/collect audit trail) is a separate
  future task.
- **Server-side permission enforcement.** All gating in this change is
  UI-level (hide/show buttons per role), matching the app's existing threat
  model (no service-layer role checks anywhere in `Services/*.cs` today).
  A defense-in-depth guard in `BookService.SoftDeleteBook` is noted as a
  stretch item in the plan but not required.
- **No FK linking `IssuesBooks` to `Users`** — borrower loan/fine matching
  remains by email equality, an existing accepted limitation (see
  role-based-multi-user-forms.md).
- **No broader UI/UX redesign** (colors, modern styling) beyond the button
  restacking needed for the new Admin layout.

## Migration / data notes

No schema changes required for Phases 1–2 (UI-only). Phase 3 charts read
existing tables via existing service methods — no new columns. Phases 4–5
(Borrower catalog/fines) are read-only against existing tables — no new
columns. If real fine persistence is ever built, it would need a new table;
not part of this change.

Existing seed accounts (see role-based-multi-user-forms.md) for manual
verification: `adminTaufiq` (Admin), `staffTaufiq` (Staff). A Borrower
account is created by registering through `RegisterForm` (always defaults
new sign-ups to Borrower — see `UserService.Register`).
