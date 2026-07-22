using System.Linq;

namespace Library_Management_System_project.Services
{
    // Guardrails checked before a Borrower's self-request is created.
    // See docs/borrower-self-request.md for the full design.
    public static class BorrowingPolicy
    {
        public const int MaxConcurrentLoans = 5;

        public static (bool Ok, string Message) Check(string email, int bookId, string bookTitle, string bookStatus)
        {
            if (bookStatus != "Available")
                return (false, "This book is not available.");

            using (var db = new LibraryDataContext())
            {
                bool hasActiveLoan = db.IssuesBooks.Any(i =>
                    i.Email == email && i.Book_Title == bookTitle && i.Return_Status == "Not Returned");
                bool hasPendingRequest = db.BookRequests.Any(r =>
                    r.Email == email && r.BookID == bookId && r.Status == "Pending");
                if (hasActiveLoan || hasPendingRequest)
                    return (false, "You already have an active loan or pending request for this book.");

                // Reads the ledger, not ComputeAccruing: a fine is only ever
                // written (and only ever cleared) via FineService, so this is
                // the one signal that actually changes when a fine is paid.
                if (new FineService().HasUnpaid(email))
                    return (false, "You have unpaid fines. Please clear them before requesting another book.");

                int activeLoans = db.IssuesBooks.Count(i => i.Email == email && i.Return_Status == "Not Returned");
                int pendingRequests = db.BookRequests.Count(r => r.Email == email && r.Status == "Pending");
                if (activeLoans + pendingRequests >= MaxConcurrentLoans)
                    return (false, $"You have reached the limit of {MaxConcurrentLoans} active loans/requests.");
            }

            return (true, null);
        }
    }
}
