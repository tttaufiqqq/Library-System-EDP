using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project.Services
{
    // Lifecycle for Borrower self-requests (BookRequests table).
    // See docs/borrower-self-request.md for the full design.
    public class RequestService : DataService
    {
        private readonly IssueService _issueService = new IssueService();
        private readonly BookService _bookService = new BookService();

        public void CreateRequest(BookRequest request) =>
            WithContext(db =>
            {
                db.BookRequests.InsertOnSubmit(request);
                db.SubmitChanges();
            });

        public List<BookRequest> GetPendingRequests() =>
            WithContext(db => db.BookRequests.Where(r => r.Status == "Pending").ToList());

        public (bool Approved, string Message) Approve(int requestId, string staffUsername)
        {
            BookRequest request;
            string currentBookStatus;

            using (var db = new LibraryDataContext())
            {
                request = db.BookRequests.SingleOrDefault(r => r.RequestID == requestId && r.Status == "Pending");
                if (request == null) return (false, "Request not found or already decided.");

                var book = db.Bookks.SingleOrDefault(b => b.BookID == request.BookID);
                currentBookStatus = book?.Book_Status;

                if (currentBookStatus != "Available")
                {
                    request.Status = "Rejected";
                    request.Decided_Date = DateTime.Today;
                    request.Decided_By = staffUsername;
                    db.SubmitChanges();
                    return (false, "Book no longer available; request auto-rejected.");
                }
            }

            string issueId = _issueService.GenerateIssueId();
            _issueService.IssueBook(new IssuesBook
            {
                IssueID = issueId,
                Full_Name = request.Full_Name,
                Contact = request.Contact,
                Email = request.Email,
                Book_Title = request.Book_Title,
                Author = request.Author,
                Return_Status = "Not Returned",
                Issue_Date = DateTime.Today.ToString(),
                Return_Date = request.Return_Date?.ToString() ?? DateTime.Today.ToString(),
                Insert_Date = DateTime.Today.ToString()
            });
            _bookService.SetBookStatus(request.BookID, "Issued");

            WithContext(db =>
            {
                var r = db.BookRequests.SingleOrDefault(x => x.RequestID == requestId);
                if (r == null) return;

                r.Status = "Approved";
                r.Decided_Date = DateTime.Today;
                r.Decided_By = staffUsername;
                db.SubmitChanges();
            });

            return (true, $"Request approved - loan {issueId} created.");
        }

        public bool Reject(int requestId, string staffUsername) =>
            WithContext(db =>
            {
                var request = db.BookRequests.SingleOrDefault(r => r.RequestID == requestId && r.Status == "Pending");
                if (request == null) return false;

                request.Status = "Rejected";
                request.Decided_Date = DateTime.Today;
                request.Decided_By = staffUsername;
                db.SubmitChanges();
                return true;
            });
    }
}
