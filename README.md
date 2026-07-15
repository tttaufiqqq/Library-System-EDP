# Library Management System

A Windows Forms (.NET Framework 4.7.2) application for managing a library's books, users, and book issues/returns.

## Features

- User registration and login (PBKDF2 password hashing)
- Dashboard with registered user statistics
- Add, view, update, and delete books with cover images
- Issue books to users and track return status
- Return book processing with fine calculation

## Tech Stack

- **Framework:** .NET Framework 4.7.2
- **Language:** C#
- **UI:** Windows Forms
- **ORM:** LINQ to SQL
- **Database:** SQL Server (LocalDB or remote)
- **NuGet:** EntityFramework 6.4.4

## Prerequisites

- [.NET Framework 4.7.2 Developer Pack](https://aka.ms/msbuild/developerpacks)
- SQL Server (LocalDB, Express, or remote instance)
- JetBrains Rider or Visual Studio 2022

## Database Setup

Run `setup_database.sql` on your SQL Server instance to create the `Library` database and required tables.

Update the connection string in `App.config`:

```xml
<connectionStrings>
  <add name="LibraryConnectionString"
    connectionString="Server=YOUR_SERVER;Initial Catalog=Library;User Id=YOUR_USER;Password=YOUR_PASSWORD;Connect Timeout=30"
    providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Running

Open `Library Management System project.sln` in Rider or Visual Studio, build, and run (F5).

## Architecture

The project uses **Delegation Pattern** and **Repository Pattern** to separate concerns into distinct layers:

```
┌─────────────────────────────────────────────────────┐
│  Forms (UI Layer)                                   │
│  LoginForm, RegisterForm, MainForm, Dashboard,      │
│  AddBooks, IssuedBooks, ReturnBooks, Fine           │
│                                                     │
│  Forms DELEGATE all data operations to Services.    │
└──────────────────────┬──────────────────────────────┘
                       │ delegates to
┌──────────────────────▼──────────────────────────────┐
│  Services Layer  (Services/)                        │
│  UserService, BookService, IssueService,            │
│  DashboardService                                   │
│                                                     │
│  Services DELEGATE data queries to Repositories.    │
└──────────────────────┬──────────────────────────────┘
                       │ delegates to
┌──────────────────────▼──────────────────────────────┐
│  Repository Layer                                   │
│  AddBooksRepository, IssueBooksRepository           │
│                                                     │
│  Implement the Abstract + Data class hierarchy.     │
│  Handle all LINQ-to-SQL database queries.           │
└──────────────────────┬──────────────────────────────┘
                       │ queries via
┌──────────────────────▼──────────────────────────────┐
│  Data Context (LibraryDataContext)                   │
│  Auto-generated LINQ-to-SQL mapping to SQL Server.  │
│  Maps to tables: Users, Books, IssuesBooks          │
└─────────────────────────────────────────────────────┘
```

### Delegation Flow

Each layer **delegates** its work to the layer below, avoiding direct coupling between UI and database:

```
Form (e.g. IssuedBooks)
  → delegates display data to →  IssueService.GetIssueDisplayData()
    → delegates query to →        IssueBooksRepository.FetchAllIssues()
      → queries via →               LibraryDataContext.IssuesBooks
```

### Abstract + Data Class Hierarchy

The repository layer implements OOP abstraction with:

| File | Role | Purpose |
|------|------|---------|
| `IDataAddBooks.cs` | **Interface** | Defines the **contract** — what properties every book DTO must have |
| `AbstractDataAddBooks.cs` | **Abstract class** | Implements shared properties; enforces that subclasses implement the contract |
| `DataAddBooks.cs` | **Concrete DTO** | Pure data container for book display data (grid binding) |
| `AddBooksRepository.cs` | **Repository** | Extends `AbstractDataAddBooks`; implements actual DB queries via LINQ-to-SQL |
| `IDataIssueBooks.cs` | **Interface** | Defines the **contract** for issue book DTOs |
| `AbstractIssueBooks.cs` | **Abstract class** | Shared property implementations for issue data |
| `DataIssueBooks.cs` | **Concrete DTO** | Pure data container for issue display data (grid binding) |
| `IssueBooksRepository.cs` | **Repository** | Extends `AbstractIssueBooks`; implements issue DB queries |

This hierarchy enforces the **Template Method** pattern: the abstract class defines the structure, and concrete repositories provide the implementation.

### Project Structure

```
├── Services/                 # Business logic layer
│   ├── BookService.cs        # Book CRUD, image management
│   ├── UserService.cs        # Registration, authentication
│   ├── IssueService.cs       # Issue/return operations
│   └── DashboardService.cs   # Aggregated statistics
├── Helpers/
│   └── PasswordHelper.cs     # PBKDF2 password hashing (SHA-256, 100k iterations)
├── IDataAddBooks.cs          # Book DTO interface
├── AbstractDataAddBooks.cs   # Book DTO abstract base
├── DataAddBooks.cs           # Book DTO implementation
├── AddBooksRepository.cs     # Book data access repository
├── IDataIssueBooks.cs        # Issue DTO interface
├── AbstractIssueBooks.cs     # Issue DTO abstract base
├── DataIssueBooks.cs         # Issue DTO implementation
├── IssueBooksRepository.cs   # Issue data access repository
├── Library.dbml              # LINQ-to-SQL data model
├── Library.designer.cs       # Auto-generated data context + entities
├── App.config                # Connection string (single source of truth)
├── StartUpScreen.cs          # Splash screen
├── LoginForm.cs              # Login form
├── RegisterForm.cs           # Registration form
├── MainForm.cs               # Main dashboard container
├── Dashboard.cs              # Statistics panel
├── AddBooks.cs               # Book management panel
├── IssuedBooks.cs            # Issue book panel
├── ReturnBooks.cs            # Return book panel
├── Fine.cs                   # Fine calculation panel
└── setup_database.sql        # Database creation script
```
