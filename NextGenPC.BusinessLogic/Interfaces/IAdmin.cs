using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic.Interfaces
{
    public interface IAdmin
    {
        List<UserDataEntities> GetAllUsersLogic();
        bool UpdateUserLogic(UserDataEntities user);
        bool DeleteUserLogic(int id);
    }
}
