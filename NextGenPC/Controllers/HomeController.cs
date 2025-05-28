using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.LogicHelper;

namespace NextGenPC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProduct _product;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductBL();
        }
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            var latestProducts = _product.GetAllProductsLogic()
                                 .OrderByDescending(p => p.Id)
                                 .Take(6)
                                 .Select(ProductMapper.ToViewModel)
                                 .ToList();

            ViewBag.NewProducts = latestProducts;
            return View();
        }
    }
}