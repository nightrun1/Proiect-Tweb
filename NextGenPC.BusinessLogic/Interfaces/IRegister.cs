using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic.Interfaces
{
    public interface IRegister
    {
        string SignUpLogic(UserDataRegisterEntities data);
    }
}
