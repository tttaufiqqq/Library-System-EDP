-- Adds a durable fine ledger and a payment ledger, plus the actual-return-date
-- column IssuesBooks was missing entirely.
--
-- Before this migration, FineCalculator.ComputeFine() recomputed the fine live
-- from (DateTime.Today - DueDate) and returned 0 the moment Return_Status
-- became "Returned" - so returning a book late silently erased its fine, and
-- "paying" a fine never persisted anything. dbo.Fines is written exactly once,
-- when the book is returned (see Services/FineService.cs Finalize), and never
-- recomputed after that. dbo.FinePayments records every payment attempt
-- separately so a failed/retried gateway call cannot double-settle a fine.
--
-- IssueID is not a real FK target: IssuesBooks' primary key is the identity
-- column ID (INT), and IssueID is a VarChar(MAX) business key ("ISS" +
-- yyyyMMddHHmmssfff, 20 chars). VarChar(MAX) columns cannot be indexed, so
-- dbo.Fines.IssueID is declared VARCHAR(100) here purely so it can carry a
-- unique index - that index is what makes Finalize() idempotent even if
-- Return Books is clicked twice.

ALTER TABLE dbo.IssuesBooks ADD Actual_Return_Date DATETIME NULL;

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
