using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextGenPC.Models.Products
{
    public class ProductDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Specifications { get; set; }
        public decimal Price { get; set; }
    }
}