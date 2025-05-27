using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NextGenPC.BusinessLogic.DBModel;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.Product.ProductActionResponse;
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

        public ProductResp AddProduct(ProdData product)
        {
            using (var db = new ProductContext())
            {
                // Verificam daca produsul deja exista
                if (db.Products.Any(p => p.Name == product.Name))
                    return new ProductResp
                    {
                        Name = product.Name,
                        Status = false,
                        Result = AddProductResult.ProductAlreadyExists
                    };

                // Cream un nou obiect ProdDbTable
                var newProduct = new ProdDbTable
                {
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    CPU = product.CPU,
                    GPU = product.GPU,
                    RAM = product.RAM,
                    Storage = product.Storage,
                    StockQuantity = product.StockQuantity,
                    Price = product.Price
                };
                // Adaugam produsul in baza de date
                db.Products.Add(newProduct);
                db.SaveChanges();

                return new ProductResp
                    {
                    Name = product.Name,
                    Status = true,
                    Result = AddProductResult.Success
                };
            }
        }


        public bool UpdateProduct(ProdData product)
        {
            using (var db = new ProductContext())
            {
                // Cautam produsul dupa ID
                var existingProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
                // Daca produsul exista, il actualizam
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.ImageUrl = product.ImageUrl;
                    existingProduct.CPU = product.CPU;
                    existingProduct.GPU = product.GPU;
                    existingProduct.RAM = product.RAM;
                    existingProduct.Storage = product.Storage;
                    existingProduct.StockQuantity = product.StockQuantity;
                    existingProduct.Price = product.Price;
                    db.SaveChanges();
                    return true;
                }
                // Daca nu exista, returnam false
                return false;
            }
        }
    }
}
