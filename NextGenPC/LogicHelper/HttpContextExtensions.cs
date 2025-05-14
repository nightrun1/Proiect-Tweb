using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NextGenPC.Domain.Entities.User.UserActionResponse;

namespace NextGenPC.LogicHelper
{
    public static class  HttpContextExtensions
    {
        public static UserResp GetUserProfile(this HttpContext context)
        {
            return (UserResp)context?.Session["__SessionObject"];
        }

        public static void SetUserProfile(this HttpContext context, UserResp data)
        {
            context.Session.Add("__SesionObject", data);
        }
    }
}