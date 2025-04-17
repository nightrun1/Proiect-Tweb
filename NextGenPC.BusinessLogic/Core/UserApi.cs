using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.DBModel;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Domain.Enums;

namespace NextGenPC.BusinessLogic.Core
{
    public class UserApi
    {
        public static bool RegisterUser(RegisterViewModel model)
        {
            using (var db = new UserContext())
            {
                if (db.Users.Any(u => u.Name == model.Name || u.Email == model.Email))
                    return false;

                var user = new UDbTable
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password, // mb hash?????
                    LastLogin = DateTime.Now,
                    LasIp = "0.0.0.0",
                    Level = URole.User
                };

                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        public static UDbTable ValidateUser(LoginViewModel model)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(u =>
                    (u.Name == model.NameOrEmail || u.Email == model.NameOrEmail) &&
                    u.Password == model.Password);
            }
        }
    }
}
