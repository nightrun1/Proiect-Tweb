using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.Product.ProductActionResponse;

namespace NextGenPC.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        List<ProductDataEntities> GetAllProductsLogic();
        ProductDataEntities GetProductByIdLogic(int id);
        ProductResp AddProductLogic(ProductDataEntities product);
        ProductResp UpdateProductLogic(ProductDataEntities product);
        ProductResp DeleteProductLogic(int id);
        List<ProductDataEntities> SearchProductsLogic(string searchTerm);
    }
}
