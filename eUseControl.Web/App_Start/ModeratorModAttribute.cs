using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web.App_Start
{
    public class ModeratorModAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;
        public ModeratorModAttribute()
        {
            var bl = new BussinesLogic();
            _session = bl.getSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminSession = (UProfileData)HttpContext.Current?.Session["__SessionObject"];

            if (adminSession != null)
            {

                var cookie = HttpContext.Current.Request.Cookies["tsud"];
                if (cookie != null)
                {
                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null && profile.Level >= URole.Moderator)
                    {
                        HttpContext.Current.Session.Add("__SessionObject", profile);
                        return;
                    }
                }
            }
            filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
        }
    }
}