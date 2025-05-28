using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Models.Products;
using NextGenPC.Models.Users;

namespace NextGenPC.LogicHelper.Mappers
{
    public class UserMapper
    {
        public static UserDataModel ToViewModel(UserDataEntities user) => new UserDataModel
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password,
            Email = user.Email,
            LastLogin = user.LastLogin,
            UserIp = user.UserIp,
            Level = user.Level
        };

        public static UserDataEntities ToEntity(UserUpdateModel user) => new UserDataEntities
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.NewPassword,
        };
    }
}