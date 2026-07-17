using System.Text.RegularExpressions;

namespace Library_Management_System_project
{
    public static class InputValidator
    {
        private static readonly Regex EmailPattern =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private static readonly Regex PhonePattern =
            new Regex(@"^[0-9+\-\s()]{7,15}$", RegexOptions.Compiled);

        public static bool IsValidEmail(string email) =>
            !string.IsNullOrWhiteSpace(email) && EmailPattern.IsMatch(email.Trim());

        public static bool IsValidPhone(string phone) =>
            !string.IsNullOrWhiteSpace(phone) && PhonePattern.IsMatch(phone.Trim());
    }
}
