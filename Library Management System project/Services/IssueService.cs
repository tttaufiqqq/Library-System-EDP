using System;
using System.Collections.Generic;
using System.Linq;
using Library_Management_System_project;

namespace Library_Management_System_project.Services
{
    public class IssueService : DataService
    {
        public string GenerateIssueId() => "ISS" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

        public void IssueBook(IssuesBook issue) =>
            WithContext(db =>
            {
                db.IssuesBooks.InsertOnSubmit(issue);
                db.SubmitChanges();
            });

        public bool UpdateIssue(string issueId, string fullName, string contact, string email,
            string bookTitle, string author, string status, DateTime issueDate, DateTime returnDate) =>
            WithContext(db =>
            {
                var issue = db.IssuesBooks.SingleOrDefault(i => i.IssueID == issueId);
                if (issue == null) return false;

                issue.Full_Name = fullName;
                issue.Contact = contact;
                issue.Email = email;
                issue.Book_Title = bookTitle;
                issue.Author = author;
                issue.Return_Status = status;
                issue.Issue_Date = issueDate.ToString("yyyy-MM-dd");
                issue.Return_Date = returnDate.ToString("yyyy-MM-dd");
                issue.Date_Update = DateTime.Today.ToString("yyyy-MM-dd");

                db.SubmitChanges();
                return true;
            });

        public bool DeleteIssue(string issueId) =>
            WithContext(db =>
            {
                var issue = db.IssuesBooks.SingleOrDefault(i => i.IssueID == issueId);
                if (issue == null) return false;

                db.IssuesBooks.DeleteOnSubmit(issue);
                db.SubmitChanges();
                return true;
            });

        public void ReturnBook(string issueId) =>
            WithContext(db =>
            {
                var issue = db.IssuesBooks.SingleOrDefault(i => i.IssueID == issueId);
                if (issue == null) return;

                issue.Return_Status = "Returned";
                issue.Date_Update = DateTime.Now.ToString();

                var book = db.Bookks.SingleOrDefault(b => b.Book_Title == issue.Book_Title);
                if (book != null)
                {
                    book.Book_Status = "Available";
                    book.Date_Update = DateTime.Today;
                }

                db.SubmitChanges();
            });

        // Borrower self-reports a return from "My Loans"; Staff verifies the
        // physical book via GetPendingReturnRequests() and finalizes with
        // ReturnBook(). See docs/borrower-self-request.md's rationale for why
        // this is a column on the existing issue row, not a new table.
        public void RequestReturn(string issueId) =>
            WithContext(db =>
            {
                var issue = db.IssuesBooks.SingleOrDefault(i =>
                    i.IssueID == issueId && i.Return_Status == "Not Returned");
                if (issue == null || issue.Return_Requested_Date != null) return;

                issue.Return_Requested_Date = DateTime.Now;
                db.SubmitChanges();
            });

        public List<IssuesBook> GetPendingReturnRequests() =>
            WithContext(db => db.IssuesBooks
                .Where(i => i.Return_Status == "Not Returned" && i.Return_Requested_Date != null)
                .ToList());

        public List<IssuesBook> GetActiveIssues() =>
            WithContext(db => db.IssuesBooks.Where(i => i.Return_Status != "Returned").ToList());

        public List<IssuesBook> GetAllIssues() =>
            WithContext(db => db.IssuesBooks.ToList());

        public List<IssuesBook> GetIssuesByEmail(string email) =>
            WithContext(db => db.IssuesBooks.Where(i => i.Email == email).ToList());

        private readonly IssueBooksRepository _repository = new IssueBooksRepository();

        public List<IssueGridRow> GetIssueDisplayData()
        {
            return _repository.FetchAllIssues();
        }

        public int GetIssuedCount() =>
            WithContext(db => db.IssuesBooks.Count(i => i.Return_Status == "Not Returned"));

        public int GetReturnedCount() =>
            WithContext(db => db.IssuesBooks.Count(i => i.Return_Status == "Returned"));
    }
}
