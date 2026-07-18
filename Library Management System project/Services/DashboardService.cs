using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Library_Management_System_project.Services
{
    public class DashboardService : DataService
    {
        public int AvailableBooks => new BookService().GetAvailableBookCount();
        public int IssuedBooks => new IssueService().GetIssuedCount();
        public int ReturnedBooks => new IssueService().GetReturnedCount();
        public int RegisteredUsers => new UserService().GetUserCount();

        public List<object> GetRegisteredUsers() => new UserService().GetRegisteredUsers();

        public List<KeyValuePair<string, int>> GetBooksByStatus() =>
            WithContext(db => db.Bookks
                .GroupBy(b => b.Book_Status ?? "Unknown")
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToList());

        public List<KeyValuePair<string, int>> GetUsersByRole() =>
            WithContext(db => db.Users
                .GroupBy(u => u.role ?? "Unknown")
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToList());

        public List<KeyValuePair<string, int>> GetIssuesByMonth() =>
            WithContext(db => db.IssuesBooks.Select(i => i.Issue_Date).ToList())
                .Select(d => DateTime.TryParseExact(d, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var parsed) ? (DateTime?)parsed : null)
                .Where(d => d.HasValue)
                .GroupBy(d => d.Value.ToString("yyyy-MM", CultureInfo.InvariantCulture))
                .OrderBy(g => g.Key)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToList();

        public List<KeyValuePair<string, int>> GetTopBorrowedBooks(int take = 5) =>
            WithContext(db => db.IssuesBooks
                .GroupBy(i => i.Book_Title)
                .Select(g => new { Title = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(take)
                .ToList())
                .Select(x => new KeyValuePair<string, int>(x.Title, x.Count))
                .ToList();
    }
}
