using CURD_in_dot_net_6_and_identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CURD_in_dot_net_6_and_identity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager
        {
            get;
        }
        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }
            var user = await _userManager.FindByEmailAsync(loginVm.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Please Enter Correct login details");
                return View(loginVm);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Please Enter Correct login details");
                return View(loginVm);
            }
            
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            IdentityUser newUser = new IdentityUser
            {
                PhoneNumber = register.Phone,
                Email = register.Email,
                UserName = register.Email
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(register);
            }
            return RedirectToAction(nameof(LogIn));
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }
    }
}
