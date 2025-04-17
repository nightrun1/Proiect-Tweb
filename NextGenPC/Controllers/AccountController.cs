using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserApi.RegisterUser(model))
                    return RedirectToAction("Login");

                ModelState.AddModelError("", "Username or Email already exists.");
            }
            return View(model);
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserApi.ValidateUser(model);
                if (user != null)
                {
                    Session["User"] = user.Name;
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login or password.");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}