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
    }
}
