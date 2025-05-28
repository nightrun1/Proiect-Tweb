using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.BLStruct;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.User;
using NextGenPC.LogicHelper;
using NextGenPC.LogicHelper.Atributes;
using NextGenPC.LogicHelper.Mappers;
using NextGenPC.Models.Products;

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
            var viewModel = users.Select(UserMapper.ToViewModel).ToList();
            ViewBag.HideFooter = true;

            return View(viewModel);
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

        //Products ActionResult
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

        public ActionResult Delete(int id)
        {
            var result = _product.DeleteProductLogic(id);
            if (result.Status)
            {
                TempData["SuccessMessage"] = "Produsul a fost șters cu succes.";
            }

            else
            {
                TempData["ErrorMessage"] = "Eroare la ștergerea produsului.";
            }

            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductDataCreateModel productModel)
        {
            if (ModelState.IsValid)
            {
                var data = new ProductDataEntities
                {
                    Name = productModel.Name,
                    ImageUrl = productModel.ImageUrl,
                    CPU = productModel.CPU,
                    GPU = productModel.GPU,
                    RAM = productModel.RAM,
                    Storage = productModel.Storage,
                    StockQuantity = productModel.StockQuantity,
                    Price = productModel.Price
                };

                try
                {
                    var product = _product.AddProductLogic(data);

                    if (product.Status)
                    {
                        TempData["SuccessMessage"] = "Produsul a fost creat cu succes.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Produsul nu este adaugat. Eroarea: " + product.Result;
                    }
                }
                catch
                (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    TempData["ErrorMessage"] = "Produsul nu este adaugat. Eroare";
                    return View(productModel);
                }
                return RedirectToAction("Products");

            }

            return View(productModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _product.GetProductByIdLogic(id);
            if (product == null) return HttpNotFound();

            var model = new ProductDataCreateModel
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                CPU = product.CPU,
                GPU = product.GPU,
                RAM = product.RAM,
                Storage = product.Storage,
                StockQuantity = product.StockQuantity,
                Price = product.Price
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductDataCreateModel productModel)
        {
            if (ModelState.IsValid)
            {
                var data = new ProductDataEntities
                {
                    Id = productModel.Id,
                    Name = productModel.Name,
                    ImageUrl = productModel.ImageUrl,
                    CPU = productModel.CPU,
                    GPU = productModel.GPU,
                    RAM = productModel.RAM,
                    Storage = productModel.Storage,
                    StockQuantity = productModel.StockQuantity,
                    Price = productModel.Price
                };

                try
                {
                    var product = _product.UpdateProductLogic(data);

                    if (product.Status)
                    {
                        TempData["SuccessMessage"] = "Produsul a fost creat cu succes.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Produsul nu este adaugat. Eroarea: " + product.Result;
                    }
                }
                catch
                (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    TempData["ErrorMessage"] = "Produsul nu este adaugat. Eroare";
                    return View(productModel);
                }
                return RedirectToAction("Products");

            }

            return View(productModel);
        }
    }
}