using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TestIdentity.Identity;
using TestIdentity.ViewModel;

namespace TestIdentity.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDBContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var password = Crypto.HashPassword(vm.Password);
                var user = new ApplicationUser()
                {
                    Email = vm.Email,
                    UserName = vm.Username,
                    PasswordHash = password,
                    City = vm.City,
                    Country = vm.Country,
                    Birthday = vm.DateOfBirth,
                    Address = vm.Address,
                    PhoneNumber = vm.Mobile
                };

                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid Data");
                return View();
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            var appDbContext = new ApplicationDBContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(vm.Username, vm.Password);
            if (user != null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                if(userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else if(userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Manager" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid Data");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authincationManager = HttpContext.GetOwinContext().Authentication;
            authincationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Profile()
        {
            var appDbContext = new ApplicationDBContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }

    }
}

