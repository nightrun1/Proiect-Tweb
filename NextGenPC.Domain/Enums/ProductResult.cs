using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenPC.Domain.Enums
{
    public enum ProductResult
    {
        Success,
        ProductAlreadyExists,
        ProductNotFound,
        InvalidProductData,
        DatabaseError,
        UnknownError
    }
}
