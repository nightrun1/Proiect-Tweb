using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NextGenPC.Domain.Entities.User.UserActionResponse
{
    public class UserCookieResp
    {
        public HttpCookie cookie { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId{ get; set; }
        public bool Status { get; set; } = true;
    }
}
