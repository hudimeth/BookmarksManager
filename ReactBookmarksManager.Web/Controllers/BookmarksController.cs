using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactBookmarksManager.Data;
using ReactBookmarksManager.Web.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace ReactBookmarksManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private string _connectionString;
        public BookmarksController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [HttpPost]
        [Authorize]
        [Route("addbookmark")]
        public void AddBookmark(Bookmark bookmark)
        {
            var repo = new BookmarksRepo(_connectionString);
            repo.Add(bookmark);
        }
        [HttpGet]
        [Authorize]
        [Route("getbookmarksforuser")]
        public List<Bookmark> GetBookmarksForUser(int userId)
        {
            var repo = new BookmarksRepo(_connectionString);
            return repo.GetBookmarksForUser(userId);
        }
        [HttpPost]
        [Authorize]
        [Route("updatebookmarktitle")]
        public void UpdateBookmarkTitle(UpdateTitleViewModel viewModel)
        {
            var repo = new BookmarksRepo(_connectionString);
            repo.UpdateBookmarkTitle(viewModel.BookmarkId, viewModel.NewTitle);
        }
        [HttpPost]
        [Authorize]
        [Route("deletebookmark")]
        public void DeleteBookmark(DeleteBookmarkViewModel vm)
        {
            var repo = new BookmarksRepo(_connectionString);
            repo.DeleteBookmark(vm.BookmarkId);
        }
        [HttpGet]
        [Route("gettopfivebookmarks")]
        public List<TopBookmark> GetTopFiveBookmarks()
        {
            var repo = new BookmarksRepo(_connectionString);
            return repo.GetTopFiveBookmarks();
        }
    }
}
