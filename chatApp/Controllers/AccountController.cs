using chatApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace chatApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager= signInManager;  
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login userLoginrData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginrData);
            }

            //logika
            await _signInManager.PasswordSignInAsync(userLoginrData.UserName, userLoginrData.Password, false, false);


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register userRegisterData) 
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterData);  
            }

            //logika
            await _userManager.CreateAsync(new UserModel
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.UserName,
            }, userRegisterData.Password);


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
