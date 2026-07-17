using System.Collections.Generic;

namespace Library_Management_System_project.Services
{
    public class DashboardService
    {
        public int AvailableBooks => new BookService().GetAvailableBookCount();
        public int IssuedBooks => new IssueService().GetIssuedCount();
        public int ReturnedBooks => new IssueService().GetReturnedCount();
        public int RegisteredUsers => new UserService().GetUserCount();

        public List<object> GetRegisteredUsers() => new UserService().GetRegisteredUsers();
    }
}
