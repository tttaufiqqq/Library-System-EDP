using System;
using System.Globalization;

namespace Library_Management_System_project
{
    // Single date format for the whole app: dd/MM/yyyy. IssuesBook stores its
    // dates as plain text columns (see Library.designer.cs), so every write
    // and read of those columns must agree on one format instead of drifting
    // per call site (this used to mix "yyyy-MM-dd" and culture-default ToString()).
    public static class DateHelper
    {
        public const string Pattern = "dd/MM/yyyy";

        public static string Format(DateTime date) => date.ToString(Pattern, CultureInfo.InvariantCulture);

        public static bool TryParse(string text, out DateTime date) =>
            DateTime.TryParseExact(text, Pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
            DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }
}
