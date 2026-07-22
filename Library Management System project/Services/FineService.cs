using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project.Services
{
    // Owns the fine LEDGER (dbo.Fines) - the payable, immutable record of what a
    // borrower owes, as opposed to FineCalculator.ComputeAccruing's live display
    // estimate for a loan that hasn't been returned yet.
    public class FineService : DataService
    {
        // Called once, from IssueService.ReturnBook, right after Return_Status
        // flips to "Returned". Idempotent: a re-entrant call for the same
        // IssueID (double-click, retry) is a no-op, backed by the
        // UX_Fines_IssueID unique index as the last line of defense.
        public void FinalizeOnReturn(string issueId) =>
            WithContext(db =>
            {
                var issue = db.IssuesBooks.SingleOrDefault(i => i.IssueID == issueId);
                if (issue == null) return;
                if (db.Fines.Any(f => f.IssueID == issueId)) return;

                DateTime? dueDate = FineCalculator.GetDueDate(issue);
                if (dueDate == null || issue.Actual_Return_Date == null) return;

                int overdueDays = (issue.Actual_Return_Date.Value.Date - dueDate.Value.Date).Days;
                if (overdueDays <= 0) return;

                db.Fines.InsertOnSubmit(new FineRecord
                {
                    IssueID = issueId,
                    Email = issue.Email,
                    Full_Name = issue.Full_Name,
                    Book_Title = issue.Book_Title,
                    Overdue_Days = overdueDays,
                    Amount = FineCalculator.Calculate(overdueDays),
                    Assessed_Date = DateTime.Now,
                    Status = "Unpaid"
                });

                db.SubmitChanges();
            });

        public List<FineRecord> GetByEmail(string email) =>
            WithContext(db => db.Fines.Where(f => f.Email == email).ToList());

        public FineRecord GetById(int fineId) =>
            WithContext(db => db.Fines.SingleOrDefault(f => f.FineID == fineId));

        public bool HasUnpaid(string email) =>
            WithContext(db => db.Fines.Any(f => f.Email == email && f.Status == "Unpaid"));

        public decimal GetOutstandingTotal(string email) =>
            WithContext(db => db.Fines
                .Where(f => f.Email == email && f.Status == "Unpaid")
                .ToList()
                .Sum(f => f.Amount));

        public List<FineRecord> GetReport() =>
            WithContext(db => db.Fines.OrderByDescending(f => f.Assessed_Date).ToList());
    }
}
