using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.Product;

namespace NextGenPC.BusinessLogic.Core
{
    public class ProductApi
    {
        public List<ProdData> GetProducts()
        {
            return new List<ProdData>
            {
                new ProdData
                {
                    Name = "Calculator Gaming Unity X01",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2025/04/calculator-gaming-unity-x01-xstore-md-49.webp",
                    CPU = "Ryzen 5 5500",
                    GPU = "RTX 3050",
                    RAM = "16GB RAM",
                    Storage = "512GB SSD",
                    StockQuantity = 10,
                    Price = 11199m
                },
                new ProdData
                {
                    Name = "Setup PC Gaming X01",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2024/05/setup-240501110029-xstore.webp",
                    CPU = "Ryzen 5 5500",
                    GPU = "RTX4060",
                    RAM = "16GB DDR4",
                    Storage = "512GB SSD",
                    StockQuantity = 5,
                    Price = 23899m
                },
                new ProdData
                {
                    Name = "Calculator Gaming Raptor X07",
                    ImageUrl = "https://xstore.md/images/product/thumbs/2025/05/calculator-gaming-raptor-x07-xstore-md-57.webp",
                    CPU = "i5-12400F",
                    GPU = "RTX4060",
                    RAM = "16GB DDR4",
                    Storage = "1TB SSD",
                    StockQuantity = 8,
                    Price = 16799m
                }
            };
        }
    }
}
