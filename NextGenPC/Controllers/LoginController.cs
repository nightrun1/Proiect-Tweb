using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BusinesLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        UserLogin ???
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }*/
    }
}