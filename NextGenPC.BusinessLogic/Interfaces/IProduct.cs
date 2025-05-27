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
        List<ProdDataEntities> GetAllProductsLogic();
        ProdDataEntities GetProductByIdLogic(int id);
        ProductResp AddProductLogic(ProdDataEntities product);
        ProductResp UpdateProductLogic(ProdDataEntities product);
        ProductResp DeleteProductLogic(int id);
        List<ProdDataEntities> SearchProductsLogic(string searchTerm);
    }
}
