using HomePage.ViewModels;
using HomePageDataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePage.Controllers.Web
{
    public class AccountController : Controller
    {
        private SignInManager<HomepageUser> signInManager;

        public AccountController(SignInManager<HomepageUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("App","Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","App");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username password combination");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            if(User.Identity.IsAuthenticated)
            {
                await this.signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Index", "App");
        }
    }
}
