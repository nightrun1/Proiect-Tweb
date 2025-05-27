using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.Product;

namespace NextGenPC.BusinessLogic.DBModel
{
    public class ProductContext : DbContext
    {
        public ProductContext() :
            base("name=ShopDB")
        {
        }

        public virtual DbSet<ProdDbTable> Products { get; set; }
    }
}
