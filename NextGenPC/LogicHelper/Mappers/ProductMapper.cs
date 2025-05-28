using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Models.Products;

namespace NextGenPC.LogicHelper
{
    public static class ProductMapper
    {
        public static ProductDataModel ToViewModel(ProductDataEntities product) => new ProductDataModel
        {
            Id = product.Id,
            Name = product.Name,
            ImageUrl = product.ImageUrl,
            Specifications = product.CPU + " / " + product.GPU + " / " + product.RAM + " / " + product.Storage,
            Price = product.Price
        };

        //not used yet, but can be used in the future if needed
        /*public static ProdData ToEntity(ProductData vm) => new ProdData
        {
            Id = vm.Id,
            Name = vm.Name,
            ImageUrl = vm.ImageUrl,
            CPU = vm.CPU,
            GPU = vm.GPU,
            RAM = vm.RAM,
            Storage = vm.Storage,
            Price = vm.Price
        };*/
    }
}