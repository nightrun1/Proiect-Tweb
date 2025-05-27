using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.LogicHelper.Atributes;

namespace NextGenPC.Controllers
{
    [isAdmin]
    public class AdminController : BaseController
    {
        private readonly IAdmin _admin;

        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _admin = bl.GetAdminBL();
        }

        // GET: Admin
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