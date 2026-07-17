# Library Management System

A Windows Forms (.NET Framework 4.7.2) desktop application for managing a
library's books, users, and book issues/returns — built in C# against a
layered, event-driven architecture on top of a self-hosted SQL Server backend
and MinIO object storage.

## What this project demonstrates

- **Object-oriented design** — a custom class hierarchy (`Services/DataService`
  as an abstract base for all data-access services), an interface
  (`IImageStorageService`) decoupling business logic from a concrete storage
  provider, and encapsulated domain services (`BookService`, `IssueService`,
  `UserService`).
- **Event-driven UI** — button clicks, keyboard shortcuts (Enter-to-submit on
  login), mouse hover tooltips, a live search box reacting to `TextChanged`,
  and a `Timer`-driven splash screen progress bar.
- **LINQ and collections** — all data access goes through LINQ-to-SQL
  (`Where`, `Select`, `OrderBy`, `SingleOrDefault`) over `List<T>` collections.
- **Delegates and lambda expressions** — `Func<LibraryDataContext, T>` and
  `Action<LibraryDataContext>` power `DataService.WithContext(...)`, used by
  every service method as a one-line expression body.
- **Robust error handling** — centralized exception presentation
  (`Helpers/ErrorPresenter`) with file logging (`Helpers/AppLogger`), plus a
  global unhandled-exception handler in `Program.cs` so a failure never
  crashes the app silently.
- **Input validation** — required-field checks, email/phone format validation
  (`Helpers/InputValidator`), and date-range rules (a book can't be published
  in the future; a new issue must be dated today with a non-past return date).
- **Multi-form navigation** — a splash screen, login/registration, and a main
  shell hosting five distinct feature panels (Dashboard, Add Books, Issue
  Books, Return Books, Fine).

## Features

- User registration and login (PBKDF2 password hashing)
- Dashboard with live statistics (available books, issued/returned counts,
  registered users)
- Add, view, update, and delete books, with cover images stored in MinIO
- Live search/filter over the book catalog by title or author
- Issue books to users and track return status
- Return book processing with fine calculation

## Tech Stack

- **Framework:** .NET Framework 4.7.2
- **Language:** C#
- **UI:** Windows Forms
- **ORM:** LINQ to SQL
- **Database:** SQL Server
- **Object storage:** MinIO (book cover images)
- **NuGet:** EntityFramework 6.4.4 (referenced, unused — vestigial), Minio 6.0.4

## Self-hosted infrastructure

Both the SQL Server database and the MinIO instance backing this app run on a
self-hosted homelab, not a cloud service. The setup, hardening, and
troubleshooting notes for that homelab — including the SQL Server and MinIO
deployments this project connects to — are documented in a separate repo:

**[tttaufiqqq/oracle-db-linux-proxmox](https://github.com/tttaufiqqq/oracle-db-linux-proxmox)**

That repo covers the Proxmox-hosted database engines and MinIO deployment in
detail; this repo assumes that infrastructure already exists and only holds
the application code that talks to it.

## Prerequisites

- [.NET Framework 4.7.2 Developer Pack](https://aka.ms/msbuild/developerpacks)
- A reachable SQL Server instance (self-hosted, LocalDB, Express, or remote)
- A reachable MinIO instance (or S3-compatible storage) with a bucket for book
  cover images
- JetBrains Rider or Visual Studio 2022

## Database Setup

Run `setup_database.sql` on your SQL Server instance to create the `Library`
database and required tables. Not idempotent — don't re-run it against a
database that already has data.

## Configuration

`App.config` only holds `CHANGE_ME` placeholders so real credentials never
get committed. Real values live in `App.config.local` (gitignored) — copy
`App.config` to `App.config.local`, fill in the values below, then run
`scripts/apply-local-config.ps1` to inject them into `App.config` before
building. Two things need real values:

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
build, and run (F5).

## Architecture

The project is layered Forms → Services → Repository/DataContext, with each
layer delegating to the one below it instead of reaching past it:

```
┌─────────────────────────────────────────────────────┐
│  Forms / UserControls (UI Layer)                    │
│  LoginForm, RegisterForm, MainForm, Dashboard,      │
│  AddBooks, IssuedBooks, ReturnBooks, Fine           │
│                                                     │
│  Delegate all data operations to Services.          │
│  Catch and present exceptions via ErrorPresenter.   │
└──────────────────────┬──────────────────────────────┘
                       │ delegates to
┌──────────────────────▼──────────────────────────────┐
│  Services Layer  (Services/)                        │
│  UserService, BookService, IssueService              │
│    : DataService (abstract)                          │
│                                                     │
│  BookService depends on IImageStorageService         │
│  (interface) rather than a concrete storage class.   │
└──────────────────────┬──────────────────────────────┘
          │ WithContext(...)          │ UploadImage/DownloadImage
┌─────────▼──────────────┐  ┌─────────▼─────────────────┐
│  LibraryDataContext     │  │  ImageStorageService       │
│  (LINQ-to-SQL)          │  │  : IImageStorageService    │
│  Users, Bookks,         │  │  (MinIO client)             │
│  IssuesBooks             │  │                             │
└─────────────────────────┘  └─────────────────────────────┘
```

`IssueBooksRepository` sits alongside `IssueService` for one read path
(`GetIssueDisplayData` → the Issued Books grid), returning `IssueGridRow` DTOs
shaped for grid binding rather than raw LINQ-to-SQL entities.

### DataService — the abstract base every Service inherits

```csharp
public abstract class DataService
{
    protected T WithContext<T>(Func<LibraryDataContext, T> query) { ... }
    protected void WithContext(Action<LibraryDataContext> action) { ... }
}
```

Every `BookService`/`IssueService`/`UserService` method is a one-line
expression body routed through `WithContext`, instead of each method
hand-rolling its own `using (var db = new LibraryDataContext()) { ... }`
block.

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
│   ├── BookService.cs           # Book CRUD, image key management
│   ├── UserService.cs           # Registration, authentication
│   ├── IssueService.cs          # Issue/return operations
│   ├── DashboardService.cs      # Aggregated statistics helper (not currently wired to Dashboard.cs)
│   ├── IImageStorageService.cs  # Interface: UploadImage/DownloadImage contract
│   └── ImageStorageService.cs   # : IImageStorageService — MinIO client
├── Helpers/
│   ├── PasswordHelper.cs        # PBKDF2 password hashing (SHA-256, 100k iterations)
│   ├── ErrorPresenter.cs        # Centralized exception -> log + MessageBox
│   ├── AppLogger.cs             # Timestamped error log file
│   └── InputValidator.cs        # Email/phone format validation
├── IssueGridRow.cs              # DTO for the Issued Books grid
├── IssueBooksRepository.cs      # Issue grid-row query (LINQ-to-SQL)
├── Library.dbml                 # LINQ-to-SQL data model
├── Library.designer.cs          # Auto-generated data context + entities
├── App.config                   # Connection string + MinIO settings (CHANGE_ME placeholders)
├── Program.cs                   # Entry point; global unhandled-exception handling
├── StartUpScreen.cs             # Splash screen (Timer-driven progress bar)
├── LoginForm.cs                 # Login form
├── RegisterForm.cs              # Registration form
├── MainForm.cs                  # Main shell hosting the feature panels
├── Dashboard.cs                 # Statistics panel
├── AddBooks.cs / .Crud.cs / .Grid.cs      # Book management panel (search, CRUD, grid)
├── IssuedBooks.cs / .Crud.cs / .Grid.cs / .Hover.cs  # Issue book panel
├── ReturnBooks.cs                # Return book panel
├── Fine.cs                       # Fine calculation panel
└── setup_database.sql            # Database creation script
```
