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

        public bool UpdateUser(UserDataEntities user)
        {
            using (var db = new UserContext())
            {
                // Cautam utilizatorul dupa ID
                var existingUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    // Actualizam datele utilizatorului
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    existingUser.Level = user.Level;
                    existingUser.LastLogin = user.LastLogin;
                    existingUser.UserIp = user.UserIp;
                    // Salvam modificarile in baza de date
                    db.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var db = new UserContext())
            {
                // Cautam utilizatorul dupa ID
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    // Stergem utilizatorul
                    db.Users.Remove(user);
                    // Salvam modificarile in baza de date
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
