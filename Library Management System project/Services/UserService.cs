using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project.Services
{
    public class UserService : DataService
    {
        public User Register(string email, string username, string password) =>
            WithContext(db =>
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
            });

        public User Authenticate(string username, string password) =>
            WithContext(db =>
            {
                var user = db.Users.SingleOrDefault(u => u.username == username);
                if (user == null) return null;
                return PasswordHelper.Verify(password, user.password) ? user : null;
            });

        public int GetUserCount() =>
            WithContext(db => db.Users.Count());

        public List<object> GetRegisteredUsers() =>
            WithContext(db => db.Users.OrderBy(u => u.username)
                .Select(u => new { u.userId, u.username, u.date_register })
                .ToList<object>());
    }
}
