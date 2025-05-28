using System;
using System.Collections.Generic;
using System.Linq;
using NextGenPC.BusinessLogic.DBModel;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.Product.ProductActionResponse;
using NextGenPC.Domain.Enums;

namespace NextGenPC.BusinessLogic.Core
{
    public class ProductAPI
    {
        public List<ProductDataEntities> GetProducts()
        {
            using (var db = new ProductContext())
            {
                // Verificam daca exista produse in baza de date
                if (db.Products.Any())
                {
                    // Daca exista, le returnam
                    return db.Products.Select(p => new ProductDataEntities
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
                    return new List<ProductDataEntities>();
                }
            }
        }

        public ProductDataEntities GetProductById(int id)
        {
            using (var db = new ProductContext())
            {
                // Cautam produsul dupa ID
                var product = db.Products.FirstOrDefault(p => p.Id == id);
                // Daca produsul exista, il returnam
                if (product != null)
                {
                    return new ProductDataEntities
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

        public ProductResp AddProduct(ProductDataEntities product)
        {
            using (var db = new ProductContext())
            {
                // Verificam daca produsul deja exista
                if (db.Products.Any(p => p.Name == product.Name))
                    return new ProductResp
                    {
                        Name = product.Name,
                        Status = false,
                        Result = ProductResult.ProductAlreadyExists
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
                    Price = product.Price,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                };
                // Adaugam produsul in baza de date
                db.Products.Add(newProduct);
                db.SaveChanges();

                return new ProductResp
                    {
                    Name = product.Name,
                    Status = true,
                    Result = ProductResult.Success
                };
            }
        }


        public ProductResp UpdateProduct(ProductDataEntities product)
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
                    existingProduct.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                    return new ProductResp
                    {
                        Name = product.Name,
                        Status = true,
                        Result = ProductResult.Success
                    };
                }
                // Daca nu exista, returnam false
                return new ProductResp
                {
                    Name = product.Name,
                    Status = false,
                    Result = ProductResult.ProductNotFound
                };
            }
        }

        public ProductResp DeleteProduct(int id)
        {
            using (var db = new ProductContext())
            {
                // Cautam produsul dupa ID
                var product = db.Products.FirstOrDefault(p => p.Id == id);
                // Daca produsul exista, il stergem
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return new ProductResp
                    {
                        Name = product.Name,
                        Status = true,
                        Result = ProductResult.Success
                    };
                }
                // Daca nu exista, returnam false
                return new ProductResp
                {
                    Name = null,
                    Status = false,
                    Result = ProductResult.ProductNotFound
                };
            }
        }

        public List<ProductDataEntities> SearchProducts(string searchTerm)
        {
            using (var db = new ProductContext())
            {
                // Cautam produsele care contin termenul de cautare in nume, CPU, GPU, RAM sau Storage
                return db.Products
                    .Where(p => p.Name.Contains(searchTerm) ||
                                p.CPU.Contains(searchTerm) ||
                                p.GPU.Contains(searchTerm) ||
                                p.RAM.Contains(searchTerm) ||
                                p.Storage.Contains(searchTerm))
                    .Select(p => new ProductDataEntities
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
        }
    }
}
