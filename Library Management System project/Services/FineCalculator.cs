using System;

namespace Library_Management_System_project.Services
{
    public static class FineCalculator
    {
        public const decimal FineRatePerDay = 5m;
        public const decimal FineCapAmount = 50m;

        public static decimal Calculate(int overdueDays) =>
            Math.Min(overdueDays * FineRatePerDay, FineCapAmount);

        // IssuesBooks.Return_Date holds the DUE date despite its name - there is
        // no column named DueDate. This is the one place that fact is decoded.
        public static DateTime? GetDueDate(IssuesBook issue) =>
            DateHelper.TryParse(issue.Return_Date, out DateTime dueDate) ? dueDate : (DateTime?)null;

        // Live projection for a loan that has NOT been returned yet - display
        // only, never payable. Once returned, the payable amount lives in
        // dbo.Fines (see FineService.FinalizeOnReturn) and this always returns 0m.
        public static decimal ComputeAccruing(IssuesBook issue)
        {
            if (issue.Return_Status == "Returned") return 0m;

            DateTime? dueDate = GetDueDate(issue);
            if (dueDate == null) return 0m;

            int overdueDays = (DateTime.Today - dueDate.Value).Days;
            return overdueDays > 0 ? Calculate(overdueDays) : 0m;
        }
    }
}
