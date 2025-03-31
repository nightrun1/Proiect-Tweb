using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.Interfaces;

namespace NextGenPC.BusinessLogic
{
    public class BusinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
