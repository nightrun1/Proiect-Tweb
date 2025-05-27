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
        List<ProdData> GetAllProductsLogic();
        ProdData GetProductByIdLogic(int id);
        ProductResp AddProductLogic(ProdData product);

    }
}
