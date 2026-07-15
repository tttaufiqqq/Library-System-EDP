using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project.Services
{
    public class UserService
    {
        public User Register(string email, string username, string password)
        {
            using (var db = new LibraryDataContext())
            {
                var existing = db.Users.FirstOrDefault(u => u.username == username);
                if (existing != null)
                    return null;

                var user = new User
                {
                    email = email,
                    username = username,
                    password = PasswordHelper.Hash(password),
                    date_register = DateTime.Today
                };

                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                return user;
            }
        }

        public User Authenticate(string username, string password)
        {
            using (var db = new LibraryDataContext())
            {
                var user = db.Users.SingleOrDefault(u => u.username == username);
                if (user == null) return null;
                return PasswordHelper.Verify(password, user.password) ? user : null;
            }
        }

        public int GetUserCount()
        {
            using (var db = new LibraryDataContext())
            {
                return db.Users.Count();
            }
        }

        public List<object> GetRegisteredUsers()
        {
            using (var db = new LibraryDataContext())
            {
                return db.Users.OrderBy(u => u.username)
                    .Select(u => new { u.userId, u.username, u.date_register })
                    .ToList<object>();
            }
        }
    }
}
