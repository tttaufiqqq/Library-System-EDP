using System;

namespace Library_Management_System_project.Services
{
    public static class FineCalculator
    {
        public const decimal FineRatePerDay = 5m;

        public static decimal Calculate(int overdueDays) => overdueDays * FineRatePerDay;

        public static decimal ComputeFine(IssuesBook issue)
        {
            if (issue.Return_Status == "Returned") return 0m;
            if (!DateTime.TryParse(issue.Return_Date, out DateTime dueDate)) return 0m;

            int overdueDays = (DateTime.Today - dueDate).Days;
            return overdueDays > 0 ? Calculate(overdueDays) : 0m;
        }
    }
}
