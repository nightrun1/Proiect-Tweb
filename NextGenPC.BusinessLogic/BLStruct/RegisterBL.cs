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
    public class RegisterBL : UserApi, IRegister
    {
        public string SignUpLogic(UDataRegister data)
        {
            return RegisterUser(data);
        }
    }
}
