-- Adds dbo.IssuesBooks.Return_Requested_Date so Borrowers can self-report a
-- return from "My Loans"; Staff then verifies the physical book and
-- confirms via Return Books, which also flips the book back to Available
-- (see IssueService.RequestReturn / ReturnBook). NULL means no return has
-- been requested yet - Staff's Return Books queue only lists issues where
-- this is set. Kept on IssuesBooks itself (not a new table, unlike
-- BookRequests) since a return request is always 1:1 with an existing
-- issue row, not a fresh entity with its own lifecycle before one exists.

ALTER TABLE dbo.IssuesBooks ADD Return_Requested_Date DATETIME NULL;
