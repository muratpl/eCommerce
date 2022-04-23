using eCommerce.UI.Identity;
using eCommerce.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> _UserManager;
        private RoleManager<ApplicationRole> _RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            var user = new ApplicationUser();

            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult sonuc = _UserManager.Create(user, model.Password);

                if (sonuc.Succeeded)
                {
                    _UserManager.AddToRole(user.Id, "user");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("UserRegisterError", "Unfortunately, your registration failed!");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _UserManager.Find(model.Username, model.Password);
                if(user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = _UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }
                    else{
                        return RedirectToAction("Index", "Home");
                    }

                    
                }
                else
                {
                    ModelState.AddModelError("UserLoginError", "Kulanıcı giriş yapma durumu başarısız!");
                }
            }
            return View();
        }



        [HttpGet]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}