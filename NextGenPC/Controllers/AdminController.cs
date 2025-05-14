using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.LogicHelper.Atributes;

namespace NextGenPC.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        [isAdmin]
        public ActionResult Index()
        {
            SessionStatus();
            if(Session["LoginStatus"] == null || Session["LoginStatus"].ToString() != "login")
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.HideFooter = true;
            return View();
        }
    }
}