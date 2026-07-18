-- Adds dbo.BookRequests for Borrower self-service book requests.
-- Kept separate from dbo.IssuesBooks so existing Staff issue/return/fine
-- code (which reads IssuesBooks.Return_Status) needs no changes.
-- See docs/borrower-self-request.md for the full design.

CREATE TABLE dbo.BookRequests (
    RequestID       INT IDENTITY PRIMARY KEY,
    Email           VARCHAR(MAX),
    Full_Name       VARCHAR(MAX),
    Contact         VARCHAR(MAX),
    BookID          INT NOT NULL,
    Book_Title      VARCHAR(MAX),
    Author          VARCHAR(MAX),
    Requested_Date  DATE,
    Return_Date     DATE,
    Status          VARCHAR(20) NOT NULL DEFAULT 'Pending',
    Decided_Date    DATE NULL,
    Decided_By      VARCHAR(MAX) NULL
);
