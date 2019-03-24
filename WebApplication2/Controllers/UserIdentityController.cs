using BlazorApplication1.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserIdentityController : Controller
    {
        private SignInManager<ApplicationUser> SignInManager { get; }

        private UserManager<ApplicationUser> UserManager { get; }

        public UserIdentityController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager
        )
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public UserIdentity Get()
        {
            return new UserIdentity
            {
                IsSignedIn = SignInManager.IsSignedIn(User),
                Name = UserManager.GetUserName(User)
            };
        }
    }
}
