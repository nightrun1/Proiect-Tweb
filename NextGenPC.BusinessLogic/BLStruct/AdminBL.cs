using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.Product.ProductActionResponse;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic.BLStruct
{
    public class AdminBL : AdminAPI, IAdmin
    {

        public bool DeleteUserLogic(int id)
        {
            return DeleteUser(id);
        }

        public List<UserDataEntities> GetAllUsersLogic()
        {
            return GetAllUsers();
        }

        public UserDataEntities GetUserByIdLogic(int id)
        {
            return GetUserById(id);
        }

        public bool UpdateUserLogic(UserDataEntities user)
        {
            return UpdateUser(user);
        }
    }
}
