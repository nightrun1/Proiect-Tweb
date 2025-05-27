using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.DBModel;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Domain.Entities.User.UserActionResponse;
using NextGenPC.Domain.Enums;

namespace NextGenPC.BusinessLogic.Core
{
    public class AdminAPI
    {
        public List<UserDataEntities> GetAllUsers()
        {
            using (var db = new UserContext())
            {
                // Verificam daca exista utilizatori in baza de date
                if (db.Users.Any())
                {
                    // Daca exista, le returnam
                    return db.Users.Select(u => new UserDataEntities
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Email = u.Email,
                        Level = u.Level,
                        LastLogin = u.LastLogin,
                        UserIp = u.UserIp
                    }).ToList();
                }
                else
                {
                    // Daca nu exista, returnam o lista goala
                    return new List<UserDataEntities>();
                }
            }
        }

        
    }
}
