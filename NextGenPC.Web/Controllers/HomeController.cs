using Microsoft.AspNetCore.Mvc;
using NextGenPC.BusinessLogic;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Web.Models;

namespace NextGenPC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusinessLogicManager _businessLogic;

        public HomeController()
        {
            _businessLogic = new BusinessLogicManager(BusinessLogicManager.GetSessionBL());
        }

        public IActionResult Index()
        {
            ViewBag.IsAuthenticated = _businessLogic.User is SessionBL sessionBL && sessionBL.IsAuthenticated;
            ViewBag.Username = _businessLogic.User is SessionBL sessionBL ? sessionBL.UserId : null;
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                var data = new ULoginData
                {
                    Username = login.Credential,
                    Password = login.Password,
                    LastLogin = DateTime.Now
                };

                bool loginSuccess = _businessLogic.User.Login(data.Username, data.Password);
                if (loginSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View();
        }
    }
} 