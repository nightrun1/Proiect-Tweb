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
    public class ProductBL : ProductApi, IProduct
    {

        public List<ProdData> GetAllProductsLogic()
        {
            return GetProducts();
        }

        public ProdData GetProductByIdLogic(int id)
        {
            return GetProductById(id);
        }
        public ProductResp AddProductLogic(ProdData product)
        {
            return AddProduct(product);
        }
    }
}
