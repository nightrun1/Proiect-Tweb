using NextGenPC.BusinessLogic.BLStruct;
using NextGenPC.BusinessLogic.Interfaces;

namespace NextGenPC.BusinessLogic
{
    public class BusinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IRegister GetRegisterBL()
        {
            return new RegisterBL();
        }
    }
}
