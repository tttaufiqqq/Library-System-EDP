namespace Library_Management_System_project.Services
{
    public static class FineCalculator
    {
        public const decimal FineRatePerDay = 5m;

        public static decimal Calculate(int overdueDays) => overdueDays * FineRatePerDay;
    }
}
