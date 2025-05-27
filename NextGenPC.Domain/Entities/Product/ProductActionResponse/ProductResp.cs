using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Enums;

namespace NextGenPC.Domain.Entities.Product.ProductActionResponse
{
    public class ProductResp
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public ProductResult Result { get; set; }
    }
}
