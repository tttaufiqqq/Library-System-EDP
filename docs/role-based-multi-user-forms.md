# Role-Based Multi-User Forms

## What this is

Adds real user roles to the system and gives each role its own form after
login, instead of every account getting the same `MainForm` with full access.

## Roles

| Role | Account origin | Form after login |
|------|-----------------|-------------------|
| Admin | Manually promoted by an existing Admin (Manage Users panel) | `AdminMainForm` — everything Staff has, plus Manage Users |
| Staff | Existing accounts (pre-migration), or promoted by an Admin | `MainForm` — Dashboard, Add Books, Issue Books, Return Books, Fines (read-only report — see [fine-and-payment.md](fine-and-payment.md); staff no longer collects payment) |
| Borrower | Public self-registration via `RegisterForm` | `BorrowerForm` — view own loans and fines only |

`dbo.Users` gets a new `role NVARCHAR(20) NOT NULL DEFAULT 'Staff'` column.
Existing rows default to Staff (they're today's librarians); one must be
manually promoted to Admin after migration since there's no way to infer who
that should be. New public sign-ups always land as Borrower — the public
registration form was never meant to hand out staff access.

## Architecture

```
                         ┌──────────────┐
                         │  LoginForm    │
                         └──────┬───────┘
                                │ UserService.Authenticate(username, password)
                                │ returns User { ..., role }
                                ▼
                 ┌──────────────┼──────────────┐
                 │              │              │
           role=="Admin"  role=="Staff"  role=="Borrower"
                 │              │              │
                 ▼              ▼              ▼
        ┌────────────────┐ ┌──────────┐ ┌────────────────┐
        │ AdminMainForm   │ │ MainForm │ │  BorrowerForm   │
        │ (: MainForm)    │ │(unchanged)│ │ (standalone,   │
        │                 │ │           │ │  no staff nav) │
        │ inherits:       │ │ Dashboard │ │                │
        │  Dashboard      │ │ AddBooks  │ │ welcome label   │
        │  AddBooks       │ │ IssueBooks│ │ logout button   │
        │  IssuedBooks    │ │ ReturnBks │ │ read-only grid: │
        │  ReturnBooks    │ │ Fine      │ │  My Loans+Fines │
        │  Fine           │ │ LogOut    │ │ (IssueService.  │
        │ + adds:         │ └──────────┘ │  GetIssuesBy    │
        │  ManageUsers    │              │  Email(email))  │
        │  (buttonManage  │              └────────────────┘
        │   Users →       │
        │   manageUsers1  │
        │   panel)        │
        └────────┬────────┘
                 │
                 ▼
        UserService.GetRegisteredUsers() / UpdateUserRole() / DeleteUser()

  Shared bottom layer (unchanged):
  DataService.WithContext() → LibraryDataContext (LINQ-to-SQL)
    → SQL Server "Library": dbo.Users(+role), dbo.Books, dbo.IssuesBooks
```

## Why

Previously there was no role distinction at all, and borrowers weren't real
users — they existed only as free-text `Full_Name`/`Contact`/`Email` fields
inside `IssuesBooks`, typed in by staff at issue time. This change makes
Admin/Staff a real permission boundary and gives borrowers a way to see their
own loan/fine status without staff involvement.

## How

- **Login routing** (`LoginForm.cs`): after `UserService.Authenticate`
  succeeds, the returned `User.role` decides which form opens.
- **AdminMainForm** uses WinForms Visual Inheritance (`: MainForm`) to reuse
  the existing Dashboard/AddBooks/IssuedBooks/ReturnBooks/Fine layout instead
  of duplicating it, adding only a "Manage Users" button and panel.
- **BorrowerForm** is a standalone form (not MainForm-derived) — borrowers get
  no staff navigation at all, just their own read-only loan/fine grid.
- **Borrower loan matching** is by email equality
  (`IssuesBooks.Email == Users.email`) — no foreign key. This is a known,
  accepted limitation for a view-only feature; it would need to become a real
  FK if self-service borrowing is ever built.
- Fine calculation (`RM5/day`) is extracted into `Services/FineCalculator.cs`
  so both the existing `Fine.cs` panel and the new Borrower loan view share
  one constant.

## Out of scope

- No self-service borrowing/reservation flow for Borrowers — view-only for now.
- No broader UI/UX redesign (colors, modern styling) — separate future task.
- No FK linking `IssuesBooks` to `Users`.

## Migration

`Migrations/001_add_user_role.sql` adds the `role` column. **Already applied**
to the live homelab DB (2026-07-17), run directly via SSH + sqlcmd using `sa`
credentials since the app's own `library_app` account only has
SELECT/INSERT/UPDATE/DELETE on `dbo.Users`, not `ALTER`. Existing accounts
(`tttaufiqqq`, `taufiq`) defaulted to Staff automatically.

Two ready-to-use seed accounts were created at the same time instead of
manually promoting an existing user:
- `adminTaufiq` — role Admin
- `staffTaufiq` — role Staff

Full implementation plan and phase checklist:
`C:\Users\taufi\.claude\plans\abundant-wishing-chipmunk.md`
