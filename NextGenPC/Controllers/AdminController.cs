using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.LogicHelper;
using NextGenPC.LogicHelper.Atributes;

namespace NextGenPC.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdmin _admin;
        private readonly IProduct _product;

        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _admin = bl.GetAdminBL();
            _product = bl.GetProductBL();

        }

        // GET: Admin
        [isAdmin]
        public ActionResult Index()
        {
            SessionStatus();
            if (Session["LoginStatus"] == null || Session["LoginStatus"].ToString() != "login")
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.HideFooter = true;
            return View();
        }

        [isAdmin]
        public ActionResult Users()
        {
            SessionStatus();
            if (Session["LoginStatus"] == null || Session["LoginStatus"].ToString() != "login")
            {
                return RedirectToAction("Login", "Account");
            }

            var users = _admin.GetAllUsersLogic();
            ViewBag.HideFooter = true;
            return View(users);
        }

        [isAdmin]
        public ActionResult Orders()
        {
            SessionStatus();
            if (Session["LoginStatus"] == null || Session["LoginStatus"].ToString() != "login")
            {
                return RedirectToAction("Login", "Account");
            }

            //var orders = _admin.GetAllOrdersLogic();
            ViewBag.HideFooter = true;
            return View();
        }

        [isAdmin]
        public ActionResult Products()
        {
            SessionStatus();
            if (Session["LoginStatus"] == null || Session["LoginStatus"].ToString() != "login")
            {
                return RedirectToAction("Login", "Account");
            }

            var products = _product.GetAllProductsLogic();
            var viewModel = products.Select(ProductMapper.ToViewModel).ToList();
            ViewBag.HideFooter = true;
            return View(viewModel);
        }
    }
}