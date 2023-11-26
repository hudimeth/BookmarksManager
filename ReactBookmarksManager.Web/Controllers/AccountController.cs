using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactBookmarksManager.Data;
using ReactBookmarksManager.Web.ViewModels;
using System.Security.Claims;

namespace ReactBookmarksManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private string _connectionString;
        public AccountController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [HttpPost]
        [Route("signup")]
        public void SignUp(SignUpViewModel viewModel)
        {
            var repo = new UsersRepo(_connectionString);
            var user = new User
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email
            };
            repo.AddUser(user, viewModel.Password);
        }
        [HttpPost]
        [Route("login")]
        public User Login(LoginViewModel viewModel)
        {
            var repo = new UsersRepo(_connectionString);
            var user = repo.Login(viewModel.Email, viewModel.Password);
            if(user == null)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim("user", viewModel.Email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();
            return user;
        }
        [HttpGet]
        [Route("getcurrentuser")]
        public User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var repo = new UsersRepo(_connectionString);
            return repo.GetByEmail(User.Identity.Name);
        }
        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }
        [HttpGet]
        [Route("getcurrentuserid")]
        public int GetCurrentUserId()
        {
            var user = GetCurrentUser();
            return user.Id;
        }
    }
}
