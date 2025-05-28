using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.Product.ProductActionResponse;

namespace NextGenPC.BusinessLogic.BLStruct
{
    public class ProductBL : ProductAPI, IProduct
    {

        public List<ProductDataEntities> GetAllProductsLogic()
        {
            return GetProducts();
        }

        public ProductDataEntities GetProductByIdLogic(int id)
        {
            return GetProductById(id);
        }
        public ProductResp AddProductLogic(ProductDataEntities product)
        {
            return AddProduct(product);
        }

        public ProductResp UpdateProductLogic(ProductDataEntities product)
        {
            return UpdateProduct(product);
        }

        public ProductResp DeleteProductLogic(int id)
        {
            return DeleteProduct(id);
        }

        public List<ProductDataEntities> SearchProductsLogic(string searchTerm)
        {
            return SearchProducts(searchTerm);
        }
    }
}
