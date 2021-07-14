using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthMVC1.Controllers {
    public class HomeController : Controller {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() {
            return View();
        }
        [Authorize]
        [Route("[action]")]
        public IActionResult Secret() {
            return View();
        }

        [Route("[action]")]
        public IActionResult Login() {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string userName, string password) {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
                await _signInManager.PasswordSignInAsync(user, password, false, false) ;
            return RedirectToAction("Index");
        }


        [Route("[action]")]
        public IActionResult Register() {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string username, string password) {
            var user = new IdentityUser {
                UserName = username
            };
            await _userManager.CreateAsync(user, password);
          
            return RedirectToAction("Login");
        }
        [Route("[action]")]
        public async Task<IActionResult> LogOutAsync() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
