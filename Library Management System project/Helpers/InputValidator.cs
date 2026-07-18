using System.Text.RegularExpressions;

namespace Library_Management_System_project
{
    public static class InputValidator
    {
        private static readonly Regex EmailPattern =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        // Malaysian numbers only: optional +60/60/0 prefix, then either a
        // mobile prefix (01 + a valid second digit) or a landline area code
        // (03-09), followed by enough digits to meet the real minimum length
        // for that prefix (mobiles: 7 digits, or 8 for 011 numbers;
        // landlines: 6-8 digits depending on region).
        private static readonly Regex PhonePattern =
            new Regex(@"^(\+?60|0)(1[0-46-9]\d{7,8}|[3-9]\d{6,8})$", RegexOptions.Compiled);

        public static bool IsValidEmail(string email) =>
            !string.IsNullOrWhiteSpace(email) && EmailPattern.IsMatch(email.Trim());

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            string cleaned = Regex.Replace(phone.Trim(), @"[\s\-]", "");
            return PhonePattern.IsMatch(cleaned);
        }
    }
}
