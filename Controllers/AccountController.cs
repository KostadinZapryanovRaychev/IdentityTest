using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFromScratch.Controllers
{


    public class AccountController : Controller
    {
        private UserManager<Customer> UserManager { get; }
        private SignInManager<Customer> SignInManager { get; }
        public AccountController(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task <IActionResult> Register(CustomerViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var customer = new Customer {UserName=model.UserName , Email=model.Email };
                var customerRegistration = await UserManager.CreateAsync(customer, model.Password);

               if(customerRegistration.Succeeded)
                {
                    await SignInManager.SignInAsync(customer, isPersistent: model.RememberMe);
                }
                return Content("We made it ");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Login(string ReturnUrl )
        {
            var model = new LoginViewModel { ReturnUrl = ReturnUrl };
            return View(model);
        }


        [HttpPost]

        public async Task <IActionResult> Login(LoginViewModel user , string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var customer = await UserManager.FindByNameAsync(user.Username);
                var result = await SignInManager.PasswordSignInAsync(user.Username , user.Password , user.RememberMe , false);
                if (result.Succeeded)
                { 
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
                 

            }

            return View(user);
        }

        public async Task <IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            
               await SignInManager.SignOutAsync();
                return RedirectToAction("Index", "Home"); // tuka nai naglo mu kazvame da vzeme da se osuznae i ako e authenticated s Redirect To alatabaLA DA NA PRATI w Indexa na Hom Controllera
            
        }

    }
}
