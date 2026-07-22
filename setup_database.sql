CREATE DATABASE [Library];
GO

USE [Library];
GO

CREATE TABLE Users (
    userId INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(MAX),
    username VARCHAR(MAX),
    password VARCHAR(MAX),
    date_register DATE
);

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Book_Title VARCHAR(MAX),
    Author VARCHAR(MAX),
    Published_Date DATE,
    Book_Status VARCHAR(MAX),
    Date_Insert DATE,
    Date_Update DATE,
    Image VARCHAR(MAX),
    Date_Delete DATE
);

CREATE TABLE IssuesBooks (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    IssueID VARCHAR(MAX),
    Full_Name VARCHAR(MAX),
    Contact VARCHAR(MAX),
    Email VARCHAR(MAX),
    Book_Title VARCHAR(MAX),
    Author VARCHAR(MAX),
    Image VARCHAR(MAX),
    Return_Status VARCHAR(MAX),
    Issue_Date VARCHAR(MAX),
    Return_Date VARCHAR(MAX),
    Date_Update VARCHAR(MAX),
    Insert_Date VARCHAR(MAX),
    Return_Requested_Date DATETIME NULL,
    Actual_Return_Date DATETIME NULL
);
GO

-- See Migrations/004_add_fines_and_payments.sql for the rationale behind
-- this ledger design (fine finalized once at return, payments recorded
-- separately from fines).
CREATE TABLE dbo.Fines (
    FineID          INT IDENTITY PRIMARY KEY,
    IssueID         VARCHAR(100) NOT NULL,
    Email           VARCHAR(MAX),
    Full_Name       VARCHAR(MAX),
    Book_Title      VARCHAR(MAX),
    Overdue_Days    INT NOT NULL,
    Amount          DECIMAL(10,2) NOT NULL,
    Assessed_Date   DATETIME NOT NULL,
    Status          VARCHAR(20) NOT NULL DEFAULT 'Unpaid',
    Paid_Date       DATETIME NULL
);

CREATE UNIQUE INDEX UX_Fines_IssueID ON dbo.Fines(IssueID);

CREATE TABLE dbo.FinePayments (
    PaymentID       INT IDENTITY PRIMARY KEY,
    FineID          INT NOT NULL REFERENCES dbo.Fines(FineID),
    Bill_Code       VARCHAR(100) NOT NULL,
    Reference_No    VARCHAR(100) NOT NULL,
    Amount          DECIMAL(10,2) NOT NULL,
    Channel         VARCHAR(50) NOT NULL DEFAULT 'FPX Online Banking',
    Status          VARCHAR(20) NOT NULL DEFAULT 'Pending',
    Created_Date    DATETIME NOT NULL,
    Completed_Date  DATETIME NULL
);

CREATE UNIQUE INDEX UX_FinePayments_BillCode ON dbo.FinePayments(Bill_Code);
GO
