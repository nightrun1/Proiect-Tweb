using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.Product;

namespace NextGenPC.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        List<ProdData> GetAllProductsLogic();
    }
}
