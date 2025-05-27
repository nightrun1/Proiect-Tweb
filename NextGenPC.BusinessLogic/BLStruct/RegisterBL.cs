using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic.BLStruct
{
    public class RegisterBL : UserAPI, IRegister
    {
        public string SignUpLogic(UserDataRegisterEntities data)
        {
            return RegisterUser(data);
        }
    }
}
