using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ASP.Models;
using ASP.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistationViewModel registationViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { Email = registationViewModel.Email, UserName = registationViewModel.Email };
                IdentityResult result = await userManager.CreateAsync(user, registationViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(registationViewModel);
        }

    }
}