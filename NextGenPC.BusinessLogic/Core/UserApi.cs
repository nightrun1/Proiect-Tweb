using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.DBModel;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Domain.Enums;
using NextGenPC.Helpers.RegFlow;

namespace NextGenPC.BusinessLogic.Core
{
    public class UserApi
    {
        public string RegisterUser(UDataRegister model)
        {
            using (var db = new UserContext())
            {
                if (db.Users.Any(u => u.Name == model.Name || u.Email == model.Email))
                    return null;

                var user = new UDbTable
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password, // mb hash?????
                    LastLogin = DateTime.Now,
                    UserIp = "0.0.0.0",
                    Level = URole.User
                };

                db.Users.Add(user);
                db.SaveChanges();

                // Generam un token pentru utilizator
                string token = LogRegHelper.GenerateSecureToken(user.Id);

                return token;
            }
        }

        public string LoginUser(UDataLogin model)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u =>
                    (u.Name == model.NameOrEmail || u.Email == model.NameOrEmail) &&
                    u.Password == model.Password);
                if (user == null)
                    return null;
                // Generam un token pentru utilizator
                string token = LogRegHelper.GenerateSecureToken(user.Id);
                return token;
            }
        }

        public static UDbTable ValidateUser(UDataLogin model)
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
