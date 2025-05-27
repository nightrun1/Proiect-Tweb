using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Enums;

namespace NextGenPC.Domain.Entities.User
{
    public class UserDataEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public string UserIp { get; set; }
        public URole Level { get; set; }
    }
}
