using NextGenPC.BusinessLogic.BLStruct;
using NextGenPC.BusinessLogic.Interfaces;

namespace NextGenPC.BusinessLogic
{
    public class BusinessLogic
    {
        //user
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IRegister GetRegisterBL()
        {
            return new RegisterBL();
        }

        //product
        public IProduct GetProductBL()
        {
            return new ProductBL();
        }

        public IAdmin GetAdminBL()
        {
            return new AdminBL();
        }
    }
}
