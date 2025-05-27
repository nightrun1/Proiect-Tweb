using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NextGenPC.BusinessLogic.DBModel;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Domain.Enums;
using NextGenPC.Helpers.RegFlow;

namespace NextGenPC.BusinessLogic.Core
{
    public class ProductApi
    {
        public List<ProdData> GetProducts()
        {
            using (var db = new ProductContext())
            {
                // Verificam daca exista produse in baza de date
                if (db.Products.Any())
                {
                    // Daca exista, le returnam
                    return db.Products.Select(p => new ProdData
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        CPU = p.CPU,
                        GPU = p.GPU,
                        RAM = p.RAM,
                        Storage = p.Storage,
                        StockQuantity = p.StockQuantity,
                        Price = p.Price
                    }).ToList();
                }

                else
                {
                    // Daca nu exista, returnam o lista goala
                    return new List<ProdData>();
                }
            }
        }

        public ProdData GetProductById(int id)
        {
            using (var db = new ProductContext())
            {
                // Cautam produsul dupa ID
                var product = db.Products.FirstOrDefault(p => p.Id == id);
                // Daca produsul exista, il returnam
                if (product != null)
                {
                    return new ProdData
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
                }
                // Daca nu exista, returnam null
                return null;
            }
        }
    }
}
