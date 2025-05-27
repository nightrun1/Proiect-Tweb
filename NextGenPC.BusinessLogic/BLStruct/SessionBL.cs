using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User;
using NextGenPC.Domain.Entities.User.UserActionResponse;

namespace NextGenPC.BusinessLogic.BLStruct
{
    public class SessionBL : UserAPI, ISession
    {
        public UserCookieResp GenerateCookieByUser(int id)
        {
            return GenerateCookieByUserAction(id);
        }

        public UserResp GetUserByCookie(string sessionKey)
        {
            return GetUserByCookieAction(sessionKey);
        }

        public UserResp LogInLogic(UserDataLoginEntities data)
        {
            return LogInUser(data);
        }
    }
}
