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

        public List<ProdDataEntities> GetAllProductsLogic()
        {
            return GetProducts();
        }

        public ProdDataEntities GetProductByIdLogic(int id)
        {
            return GetProductById(id);
        }
        public ProductResp AddProductLogic(ProdDataEntities product)
        {
            return AddProduct(product);
        }

        public ProductResp UpdateProductLogic(ProdDataEntities product)
        {
            return UpdateProduct(product);
        }

        public ProductResp DeleteProductLogic(int id)
        {
            return DeleteProduct(id);
        }

        public List<ProdDataEntities> SearchProductsLogic(string searchTerm)
        {
            return SearchProducts(searchTerm);
        }
    }
}
