using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User.UserActionResponse;
using NextGenPC.Domain.Enums;

namespace NextGenPC.LogicHelper.Atributes
{
    public class isAdminAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;
        public isAdminAttribute()
        {
            var bl = new BusinessLogic.BusinesLogic();
            _session = bl.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionKey = HttpContext.Current.Request.Cookies["X-KEY"];

            if (sessionKey != null)
            {
                UserResp profile = _session.GetUserByCookie(sessionKey.Value);

                if (profile != null && profile.Role != URole.Admin)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { controller = "Home", action = "Index" }));
                }
            }
        }
    }
}