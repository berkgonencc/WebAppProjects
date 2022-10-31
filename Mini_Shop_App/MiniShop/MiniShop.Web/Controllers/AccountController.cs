using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Core;
using MiniShop.Web.Identity;
using MiniShop.Web.Models;

namespace MiniShop.Web.Controllers
{
  
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
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
            User user = new User()
            {
                UserName = registerModel.UserName,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                //Token creation codes will come for verification by email.
                TempData["Message"] = Jobs.CreateMessage("Congratulations!", "Your registration has been completed successfully.", "primary");
                return RedirectToAction("Login", "Account");
            }
            TempData["Message"] = Jobs.CreateMessage("Registiration Failed!", "Username or Email Address already taken!", "danger");
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
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is Incorrect!");
                return View(loginModel);
            }
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);
            if (result.Succeeded)
            {
                return Redirect(loginModel.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Username or Password is Incorrect!");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
            //return RedirectToAction("Index", "Home");
        }
    }
}
