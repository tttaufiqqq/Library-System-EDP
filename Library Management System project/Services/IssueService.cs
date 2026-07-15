using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project.Services
{
    public class IssueService
    {
        public void IssueBook(IssuesBook issue)
        {
            using (var db = new LibraryDataContext())
            {
                db.IssuesBooks.InsertOnSubmit(issue);
                db.SubmitChanges();
            }
        }

        public void UpdateIssue(string issueId, string fullName, string contact, string email,
            string bookTitle, string author, string status, DateTime issueDate, DateTime returnDate)
        {
            using (var db = new LibraryDataContext())
            {
                var issue = db.IssuesBooks.SingleOrDefault(i => i.IssueID == issueId);
                if (issue == null) return;

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
            }
        }

        public void ReturnBook(string issueId)
        {
            using (var db = new LibraryDataContext())
            {
                var issue = db.IssuesBooks.SingleOrDefault(i => i.IssueID == issueId);
                if (issue == null) return;

                issue.Return_Status = "Returned";
                issue.Date_Update = DateTime.Now.ToString();
                db.SubmitChanges();
            }
        }

        public List<IssuesBook> GetActiveIssues()
        {
            using (var db = new LibraryDataContext())
            {
                return db.IssuesBooks.Where(i => i.Return_Status != "Returned").ToList();
            }
        }

        public List<IssuesBook> GetAllIssues()
        {
            using (var db = new LibraryDataContext())
            {
                return db.IssuesBooks.ToList();
            }
        }

        public int GetIssuedCount()
        {
            using (var db = new LibraryDataContext())
            {
                return db.IssuesBooks.Count(i => i.Return_Status == "Not Returned");
            }
        }

        public int GetReturnedCount()
        {
            using (var db = new LibraryDataContext())
            {
                return db.IssuesBooks.Count(i => i.Return_Status == "Returned");
            }
        }
    }
}
