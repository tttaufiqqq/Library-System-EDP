# Library Management System

A Windows Forms (.NET Framework 4.7.2) application for managing a library's books, users, and book issues/returns.

## Features

- User registration and login
- Dashboard with registered user statistics
- Add, view, and manage books with cover images
- Issue books to users and track return status
- Return book processing with fine calculation
- Book directory browsing

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
