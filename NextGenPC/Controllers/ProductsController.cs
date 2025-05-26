using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextGenPC.Models.Products;

namespace NextGenPC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var Products = new List<ProductData>
            {
                new ProductData
                {
                    Name = "Calculator Gaming Unity X01",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2025/04/calculator-gaming-unity-x01-xstore-md-49.webp",
                    Specifications = "Ryzen 5 5500 / RTX 3050 / 16GB RAM / 512GB SSD",
                    Price = 11199m
                },
                new ProductData
                {
                    Name = "Setup PC Gaming X01",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2024/05/setup-240501110029-xstore.webp",
                    Specifications = "Ryzen 5 5500 / RTX4060 / 16GB DDR4 / 512GB SSD",
                    Price = 23899m
                },
                new ProductData
                {
                    Name = "Calculator Gaming Raptor X07",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2025/05/calculator-gaming-raptor-x07-xstore-md-57.webp",
                    Specifications = "i5-12400F / RTX4060 / 16GB DDR4 / 1TB SSD",
                    Price = 16799m
                },

                new ProductData
                {
                    Name = "Calculator Gaming Unity X01",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2025/04/calculator-gaming-unity-x01-xstore-md-49.webp",
                    Specifications = "Ryzen 5 5500 / RTX 3050 / 16GB RAM / 512GB SSD",
                    Price = 11199m
                },
                new ProductData
                {
                    Name = "Setup PC Gaming X01",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2024/05/setup-240501110029-xstore.webp",
                    Specifications = "Ryzen 5 5500 / RTX4060 / 16GB DDR4 / 512GB SSD",
                    Price = 23899m
                },
                new ProductData
                {
                    Name = "Calculator Gaming Raptor X07",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2025/05/calculator-gaming-raptor-x07-xstore-md-57.webp",
                    Specifications = "i5-12400F / RTX4060 / 16GB DDR4 / 1TB SSD",
                    Price = 16799m
                }
            };
            return View(Products);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}