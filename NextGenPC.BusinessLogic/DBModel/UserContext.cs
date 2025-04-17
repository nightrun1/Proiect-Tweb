using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=ShopDB")
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
