using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Models.Authentication;

namespace NextGenPC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISession _session;
        private readonly IRegister _register;

        public AccountController()
        {
            var bl = new BusinesLogic();
            _session = bl.GetSessionBL();
            _register = bl.GetRegisterBL();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            ViewBag.HideFooter = true;
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDataRegister model)
        {
            if (ModelState.IsValid)
            {
                var data = new UDataRegister
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    RegisterDataTime = DateTime.Now
                };

                try
                {
                    // call BL for token
                    string token = _register.SignUpLogic(data);

                    //if succes, else...
                }
                catch
                (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                    return View(model);
                }
                return RedirectToAction("Login");

            }

            return View(model);
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            ViewBag.HideFooter = true;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UDataLogin model)
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