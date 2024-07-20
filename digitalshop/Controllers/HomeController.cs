using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using digitalshop.Models;
using System.Diagnostics;
using digitalshop.Areas.Identity.Data;

namespace digitalshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<SampleUser> _signInManager;
        private readonly UserManager<SampleUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<SampleUser> signInManager, UserManager<SampleUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
    }
}
