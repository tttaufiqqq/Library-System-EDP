<p align="center">
  <img src="docs/images/utem-logo.png" alt="Universiti Teknikal Malaysia Melaka logo" width="220">
</p>

<h3 align="center">DITP2123 EVENT-DRIVEN PROGRAMMING</h3>
<h3 align="center">Final Group Project</h3>

# Library Management System

A Windows Forms (.NET Framework 4.7.2) desktop application for managing a
library's books, users, book issue/return, and borrower self-service — built
in C# against a layered, event-driven architecture on top of a self-hosted
SQL Server backend and MinIO object storage.

## What this project demonstrates

- **Object-oriented design** — a custom class hierarchy (`Services/DataService`
  as an abstract base for all data-access services), an interface
  (`IImageStorageService`) decoupling business logic from a concrete storage
  provider, and encapsulated domain services (`BookService`, `IssueService`,
  `UserService`, `RequestService`, `BorrowingPolicy`, `FineCalculator`,
  `DashboardService`).
- **Event-driven UI** — button clicks, keyboard shortcuts (Enter-to-submit on
  login), mouse hover tooltips, a live search box reacting to `TextChanged`,
  row-click events opening modal detail dialogs, and a `Timer`-driven splash
  screen progress bar.
- **LINQ and collections** — all data access goes through LINQ-to-SQL
  (`Where`, `Select`, `OrderBy`/`OrderByDescending`, `GroupBy`,
  `SingleOrDefault`) over `List<T>` collections.
- **Delegates and lambda expressions** — `Func<LibraryDataContext, T>` and
  `Action<LibraryDataContext>` power `DataService.WithContext(...)`, used by
  every service method as a one-line expression body.
- **Robust error handling** — centralized exception presentation
  (`Helpers/ErrorPresenter`) with file logging (`Helpers/AppLogger`), plus a
  global unhandled-exception handler in `Program.cs` so a failure never
  crashes the app silently.
- **Input validation** — required-field checks, email/Malaysian-phone format
  validation (`Helpers/InputValidator`), and date-range rules (a book can't
  be published in the future; issue/return dates can't be set in the past).
- **Role-based multi-user navigation** — a splash screen with auto-update
  check, login/registration, and three distinct role-specific shells
  (`AdminMainForm`, `MainForm`, `BorrowerForm`), each hosting its own set of
  feature panels.

## Roles

Every account has a role (`Admin` / `Staff` / `Borrower`) stored on
`dbo.Users.role`; `LoginForm` routes to a different landing form per role.
New sign-ups via `RegisterForm` always default to `Borrower`
(`UserService.Register`). All gating is UI-level (hide/show controls per
role) — there is no service-layer permission enforcement.

| Capability | Admin | Staff | Borrower |
|---|---|---|---|
| Dashboard KPI tiles | Y | Y | – |
| Dashboard analytics charts | Y | – | – |
| Add / edit book catalog | Y | Y | – |
| Delete book (soft delete) | Y | – | – |
| Browse catalog (read-only, request to borrow) | – | – | Y |
| Approve / reject borrow requests | – | Y | – |
| View issued books (read-only) | – | Y | – |
| Verify & confirm a reported return | – | Y | – |
| Collect / waive fines (mock, at the counter) | – | Y | – |
| Manage users (change role, delete) | Y | – | – |
| View own loans, request a return | – | – | Y |
| View own book-request status | – | – | Y |
| View / pay own fines (mock) | – | – | Y |

`AdminMainForm` is **not** a superset of `MainForm` — Admin is
management-focused (catalog authority + user management + analytics) and
does not do front-desk work (issue/return/fine collection).

## Features

**Book catalog**
- Cover images stored in MinIO, uploaded/looked up by object key
  (`BookService`/`ImageStorageService`).
- Staff/Admin: add, edit, and (Admin only) soft-delete books, with live
  search by title/author (`AddBooks`).
- Borrower: read-only browse with live search (`BorrowerCatalog`); clicking a
  row opens a modal (`BookDetailsDialog`) showing the cover and details, with
  a **Borrow** button when the book is Available.
- Catalog is sorted newest-added-first (`BookService.GetAllBooks`), for both
  Staff and Borrower views.

**Borrower self-request / Staff approval** (see
`docs/borrower-self-request.md`)
- A Borrower requests a book from `BookDetailsDialog` → `RequestBookDialog`
  (contact number + return date). `BorrowingPolicy` enforces: book must be
  Available, no duplicate active loan/pending request, no unpaid fines, and
  a concurrent loan+request cap (5). The request lands in `dbo.BookRequests`
  as `Pending` — the book stays Available so more than one Borrower can
  request it.
- Staff reviews pending requests in `BookRequestsPanel`; clicking a row opens
  `RequestDetailsDialog` to Approve (creates the loan via
  `IssueService.IssueBook`, marks the book Issued) or Reject. Approving a
  request whose book went unavailable in the meantime auto-rejects it
  instead of failing.
- Borrower can see the status (Pending/Approved/Rejected) of every request
  they've made in `BorrowerRequests`.

**Book issue** (`IssuedBooks`) — read-only view of all issued books
(via `IssueBooksRepository`/`IssueGridRow`); loans are created through the
approval flow above, not typed in directly.

**Borrower-initiated returns**
- A Borrower reports a return from "My Loans" (`LoanDetailsDialog` →
  `IssueService.RequestReturn`, sets `IssuesBooks.Return_Requested_Date`).
- Staff verifies the physical book is back in `ReturnBooks`, a queue of only
  the issues with a pending return request; clicking a row opens
  `ReturnConfirmDialog` to confirm via `IssueService.ReturnBook`, which
  marks the loan Returned **and** flips the book back to Available.

**Fines** — `FineCalculator` computes overdue fines (RM 5/day) from
`IssuesBooks.Return_Date`; the Staff `Fine` panel and Borrower `BorrowerFines`
view both display it. Payment is currently a UI mock (no `Fines` table or
persisted transactions).

**Dashboard** — KPI tiles (available/issued/returned books, registered
users) for Admin and Staff; Admin additionally sees four analytics charts
(books by status, users by role, issues over time, top borrowed books) via
`System.Windows.Forms.DataVisualization` and `DashboardService`.

**User management** (Admin only) — `ManageUsers`: change a user's role or
delete their account.

**Auto-update** — on launch, `StartUpScreen` calls `AutoUpdater.Start(...)`
against `update.xml` published at this repo's root on GitHub; a newer
version prompts the user to download and run the Inno Setup installer. See
`docs/auto-update/` for the full design, release workflow, and caveats.

## Tech Stack

- **Framework:** .NET Framework 4.7.2
- **Language:** C#
- **UI:** Windows Forms (+ `System.Windows.Forms.DataVisualization` for
  Admin dashboard charts)
- **ORM:** LINQ to SQL
- **Database:** SQL Server
- **Object storage:** MinIO (book cover images)
- **NuGet:** Autoupdater.NET.Official 1.9.2, Minio 6.0.4,
  Microsoft.Web.WebView2 1.0.2592.51, EntityFramework 6.4.4 (referenced,
  unused — vestigial)
- **Installer:** Inno Setup (`installer/LibrarySystem.iss`)

## Self-hosted infrastructure

Both the SQL Server database and the MinIO instance backing this app run on
a self-hosted homelab, not a cloud service. The setup, hardening, and
troubleshooting notes for that homelab — including the SQL Server and MinIO
deployments this project connects to — are documented in a separate repo:

**[tttaufiqqq/oracle-db-linux-proxmox](https://github.com/tttaufiqqq/oracle-db-linux-proxmox)**

That repo covers the Proxmox-hosted database engines and MinIO deployment in
detail; this repo assumes that infrastructure already exists and only holds
the application code that talks to it.

## Prerequisites

- [.NET Framework 4.7.2 Developer Pack](https://aka.ms/msbuild/developerpacks)
- A reachable SQL Server instance (self-hosted, LocalDB, Express, or remote)
- A reachable MinIO instance (or S3-compatible storage) with a bucket for
  book cover images
- JetBrains Rider or Visual Studio 2022

## Database Setup

1. Run `setup_database.sql` on your SQL Server instance to create the
   `Library` database and base tables (`Users`, `Books`, `IssuesBooks`).
2. Apply the migrations in `Migrations/`, in order — each is a plain
   `ALTER TABLE`/`CREATE TABLE`, not idempotent, and not auto-applied by the
   app:
   - `001_add_user_role.sql` — adds `Users.role` (defaults existing rows to
     `Staff`; promote one manually to `Admin`).
   - `002_add_book_requests.sql` — creates `dbo.BookRequests` for the
     borrower self-request flow.
   - `003_add_return_requested_date.sql` — adds
     `IssuesBooks.Return_Requested_Date` for the borrower-initiated return
     flow.

## Configuration

`App.config` holds the real connection string and MinIO settings directly.
Two things need real values:

**Connection string:**

```xml
<connectionStrings>
  <add name="LibraryConnectionString"
    connectionString="Server=YOUR_SERVER;Initial Catalog=Library;User Id=YOUR_USER;Password=YOUR_PASSWORD;Connect Timeout=30"
    providerName="System.Data.SqlClient" />
</connectionStrings>
```

**MinIO settings** (`<appSettings>`):

```xml
<add key="MinioEndpoint" value="YOUR_MINIO_HOST:9000" />
<add key="MinioAccessKey" value="YOUR_ACCESS_KEY" />
<add key="MinioSecretKey" value="YOUR_SECRET_KEY" />
<add key="MinioBucket" value="library-book-covers" />
<add key="MinioUseSSL" value="false" />
```

Use a scoped access key limited to a single bucket (`GetObject`/`PutObject`/
`DeleteObject`/`ListBucket` only) rather than the MinIO root credentials.

## Running

Open `Library Management System project.sln` in Rider or Visual Studio,
build, and run (F5). Seed accounts for manual testing (after applying
migration 001 and promoting one user): an `Admin` and a `Staff` account;
register through `RegisterForm` for a `Borrower` account.

## Building the installer

Build the `Release` configuration, then compile `installer/LibrarySystem.iss`
with Inno Setup's `ISCC.exe` to produce
`installer/Output/EDP-LibraryManagementSystem-Setup.exe`. See
`docs/auto-update/release-workflow.md` for the full ship-an-update process
(bump version, build, compile installer, publish as a GitHub Release asset,
update `update.xml`).

## Architecture

The project is layered Forms → Services → Repository/DataContext, with each
layer delegating to the one below it instead of reaching past it:

```
┌───────────────────────────────────────────────────────────────┐
│  Forms / UserControls (UI Layer)                              │
│  LoginForm, RegisterForm, AdminMainForm, MainForm,             │
│  BorrowerForm, Dashboard, AddBooks, IssuedBooks, ReturnBooks,  │
│  Fine, ManageUsers, BorrowerCatalog, BorrowerFines,            │
│  BorrowerRequests, BookRequestsPanel, and modal detail dialogs │
│  (BookDetailsDialog, RequestBookDialog, RequestDetailsDialog,  │
│  LoanDetailsDialog, ReturnConfirmDialog)                       │
│                                                                │
│  Delegate all data operations to Services.                    │
│  Catch and present exceptions via ErrorPresenter.              │
└───────────────────────────────┬────────────────────────────────┘
                                │ delegates to
┌───────────────────────────────▼────────────────────────────────┐
│  Services Layer  (Services/)                                   │
│  UserService, BookService, IssueService, RequestService          │
│    : DataService (abstract)                                     │
│  BorrowingPolicy, FineCalculator, DashboardService (stateless)  │
│                                                                │
│  BookService depends on IImageStorageService                   │
│  (interface) rather than a concrete storage class.              │
└───────────────────────────────┬────────────────────────────────┘
           │ WithContext(...)               │ UploadImage/DownloadImage
┌──────────▼──────────────┐      ┌──────────▼─────────────────┐
│  LibraryDataContext      │      │  ImageStorageService        │
│  (LINQ-to-SQL)           │      │  : IImageStorageService     │
│  Users, Bookks,          │      │  (MinIO client)             │
│  IssuesBooks, BookRequests│      │                             │
└──────────────────────────┘      └─────────────────────────────┘
```

`IssueBooksRepository` sits alongside `IssueService` for one read path
(`GetIssueDisplayData` → the Issued Books grid), returning `IssueGridRow`
DTOs shaped for grid binding rather than raw LINQ-to-SQL entities.

### DataService — the abstract base every Service inherits

```csharp
public abstract class DataService
{
    protected T WithContext<T>(Func<LibraryDataContext, T> query) { ... }
    protected void WithContext(Action<LibraryDataContext> action) { ... }
}
```

Every service method is a one-line expression body routed through
`WithContext`, instead of each method hand-rolling its own
`using (var db = new LibraryDataContext()) { ... }` block.

### IImageStorageService — the interface BookService depends on

`BookService` never constructs `ImageStorageService` directly — it holds an
`IImageStorageService` field, defaulted to a real `ImageStorageService` (MinIO)
via the parameterless constructor, but swappable via
`new BookService(customImageStorage)`. `BookService` has no compile-time
knowledge that the storage backend is MinIO.

### Project Structure

```
├── Services/
│   ├── DataService.cs           # Abstract base: shared LibraryDataContext lifecycle
│   ├── BookService.cs           # Book CRUD, image key management, catalog sort
│   ├── UserService.cs           # Registration, authentication, role/user management
│   ├── IssueService.cs          # Issue/return operations + return-request queue
│   ├── RequestService.cs        # Borrower self-request lifecycle (create/approve/reject)
│   ├── BorrowingPolicy.cs       # Guardrails checked before a self-request is created
│   ├── FineCalculator.cs        # Overdue fine calculation (RM 5/day)
│   ├── DashboardService.cs      # Aggregated KPI + chart data for Dashboard
│   ├── IImageStorageService.cs  # Interface: UploadImage/DownloadImage contract
│   └── ImageStorageService.cs   # : IImageStorageService — MinIO client
├── Helpers/
│   ├── PasswordHelper.cs        # PBKDF2 password hashing (SHA-256, 100k iterations)
│   ├── ErrorPresenter.cs        # Centralized exception -> log + MessageBox
│   ├── AppLogger.cs             # Timestamped error log file
│   ├── InputValidator.cs        # Email/Malaysian-phone format validation
│   ├── EmptyStateHelper.cs      # "No data" placeholder over empty grids
│   ├── ArrowKeyNavigationHelper.cs # Arrow-key focus navigation between controls
│   └── FormDragHelper.cs        # Drag-to-move for borderless forms
├── Migrations/                  # Hand-applied SQL migrations (001-003), see Database Setup
├── docs/
│   ├── role-based-multi-user-forms.md   # Admin/Staff/Borrower roles, original design
│   ├── role-permissions-and-dashboards.md # De-superset Admin, dashboards, catalog delete split
│   ├── borrower-self-request.md         # Self-request/approval flow design
│   └── auto-update/                     # Auto-update system design + release workflow
├── installer/
│   └── LibrarySystem.iss        # Inno Setup installer script
├── IssueGridRow.cs              # DTO for the Issued Books grid
├── IssueBooksRepository.cs      # Issue grid-row query (LINQ-to-SQL)
├── Library.dbml                 # LINQ-to-SQL data model
├── Library.designer.cs          # Auto-generated data context + entities
├── App.config                   # Connection string + MinIO settings (CHANGE_ME placeholders)
├── Program.cs                   # Entry point; global unhandled-exception handling
├── StartUpScreen.cs             # Splash screen (Timer-driven progress bar, auto-update check)
├── LoginForm.cs / RegisterForm.cs        # Auth forms
├── AdminMainForm.cs / MainForm.cs / BorrowerForm.cs  # Role-specific shells
├── Dashboard.cs / .Charts.cs     # KPI tiles + Admin-only analytics charts
├── AddBooks.cs / .Crud.cs / .Grid.cs      # Staff/Admin book catalog panel
├── IssuedBooks.cs / .Grid.cs / .Hover.cs  # Read-only issued-books view
├── ReturnBooks.cs                # Staff: pending-return-request queue
├── BookRequestsPanel.cs          # Staff: pending book-request queue
├── ManageUsers.cs                # Admin: user role/delete management
├── Fine.cs                       # Staff: fine collection panel (mock payment)
├── BorrowerCatalog.cs            # Borrower: read-only catalog browse + request
├── BorrowerFines.cs              # Borrower: own fines view (mock pay)
├── BorrowerRequests.cs           # Borrower: own book-request status
├── BookDetailsDialog.cs          # Modal: book cover/details + Borrow button
├── RequestBookDialog.cs          # Modal: contact + return date entry
├── RequestDetailsDialog.cs       # Modal: Staff approve/reject a book request
├── LoanDetailsDialog.cs          # Modal: Borrower requests a return
├── ReturnConfirmDialog.cs        # Modal: Staff verifies + confirms a return
└── setup_database.sql            # Base database creation script
```
