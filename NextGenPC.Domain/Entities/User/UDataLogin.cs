using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenPC.Domain.Entities.User
{
    public class UDataLogin
    {
        public string NameOrEmail { get; set; }
        public string Password { get; set; }
        public string UserIp { get; set; }
        public DateTime LoginDataTime { get; set; }
    }

}
