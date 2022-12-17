using BlogApp.Web.Identity;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            User user = new()
            {
                Fname = registerModel.Fname,
                Lname = registerModel.Lname,
                Email = registerModel.Email,
                UserName = registerModel.UserName,
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public IActionResult Login(string returnUrl = null)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginModel() { ReturnUrl = returnUrl });
            }
            return Redirect("~/");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) { return View(loginModel); }
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is wrong!");
                return View(loginModel);
            }
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);
            if (result.Succeeded)
            {
                return Redirect(loginModel.ReturnUrl ?? "~/");

            }
            ModelState.AddModelError("", "Username or password is wrong!");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

    }
}
