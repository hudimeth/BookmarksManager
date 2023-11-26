using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactBookmarksManager.Data
{
    public class BookmarksRepo
    {
        private string _connectionString;
        public BookmarksRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Bookmark bookmark)
        {
            using var context = new BookmarksManagerDbContext(_connectionString);
            context.Bookmarks.Add(bookmark);
            context.SaveChanges();
        }
        public List<Bookmark> GetBookmarksForUser(int userId)
        {
            using var context = new BookmarksManagerDbContext(_connectionString);
            return context.Bookmarks.Where(b => b.UserId == userId).ToList();
        }
        public void UpdateBookmarkTitle(int id, string newTitle)
        {
            using var context = new BookmarksManagerDbContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"UPDATE Bookmarks SET Title = {newTitle} WHERE Id = {id}");
            context.SaveChanges();
        }
        public void DeleteBookmark(int id)
        {
            using var context = new BookmarksManagerDbContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM BOokmarks WHERE Id={id}");
            context.SaveChanges();
        }
        public List<TopBookmark> GetTopFiveBookmarks()
        { 
            using var context = new BookmarksManagerDbContext(_connectionString);
            return context.Bookmarks.GroupBy(b => b.Url).OrderByDescending(b => b.Count()).Take(5).Select(i => new TopBookmark
            {
                Url = i.Key,
                Count = i.Count() 
            }).ToList();

        }
    }
}
