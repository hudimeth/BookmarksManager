using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactBookmarksManager.Data
{
    public class BookmarksManagerDbContext : DbContext
    {
        private string _connectionString;
        public BookmarksManagerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}
