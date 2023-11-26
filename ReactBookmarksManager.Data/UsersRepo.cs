using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ReactBookmarksManager.Data
{
    public class UsersRepo
    {
        public string _connectionString;
        public UsersRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddUser(User user, string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            user.PasswordHash = hash;
            using var context = new BookmarksManagerDbContext(_connectionString);
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User Login(string email, string password)
        {
            var user = GetByEmail(email);
            if(user == null)
            {
                return null;
            }
            var isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isValidPassword)
            {
                return null;
            }
            return user;
        }
        public User GetByEmail(string email)
        {
            using var context = new BookmarksManagerDbContext(_connectionString);
            return context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
