using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.Session;

namespace NextGenPC.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() :
            base("name=ShopDB")
        {
        }
        public virtual DbSet<SessionDbTable> Sessions { get; set; }
    }
}
