using System;
using System.Linq;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User.UserActionResponse;
using NextGenPC.LogicHelper;

namespace NextGenPC.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISession _session;
        public BaseController()
        {
            var bl = new BusinessLogic.BusinesLogic();
            _session = bl.GetSessionBL();

        }

        //session status check
        public void SessionStatus()
        {
            var sessionKey = Request.Cookies["X-KEY"];
            if (sessionKey != null)
            {
                UserResp profile = _session.GetUserByCookie(sessionKey.Value);

                if (User != null && profile.Status)
                {
                    System.Web.HttpContext.Current.SetUserProfile(profile);
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                    System.Web.HttpContext.Current.Session["UserFirstName"] = profile.Name;
                    System.Web.HttpContext.Current.Session["UserId"] = profile.UserId;
                    System.Web.HttpContext.Current.Session["URole"] = profile.Role;

                }
                else
                {
                    System.Web.HttpContext.Current.Session.Clear();
                    if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                    {
                        var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                        if (cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                        }
                    }

                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            }
        }
    }
}