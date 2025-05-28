using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NextGenPC.Domain.Enums;

namespace NextGenPC.Models.Users
{
    public class UserDataModel
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