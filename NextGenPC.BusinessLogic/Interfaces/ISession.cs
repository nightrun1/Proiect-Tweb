using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Domain.Entities.User.UserActionResponse;

namespace NextGenPC.BusinessLogic.Interfaces
{
    public interface ISession
    {
        UserResp LogInLogic(UDataLogin data);
        UserCookieResp GenerateCookieByUser(int id);

        UserResp GetUserByCookie(string sessionKey);
    }
}
