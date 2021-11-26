using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using OMS.Helpers;
using OMS.Models.Context;
using OMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Filters
{
    public class SessionHelperAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUser user;
        public SessionHelperAttribute(IUser user)
        {
            this.user = user;
        }
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    var status = (filterContext.HttpContext.Session.GetObjectFromJson<Users>("UserDetails"));

        //    if (status == null)
        //    {
        //        //return Redirect("//Users/Index");

        //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
        //        {
        //            action = "Index",
        //            controller = "Login",
        //            area = ""
        //        }));
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

        public  void OnAuthorization(AuthorizationFilterContext context)
        {
            var userSession = (context.HttpContext.Session.GetObjectFromJson<Users>("UserDetails"));
            var actionName = context.RouteData.Values["action"].ToString();
            var ControllerName = context.RouteData.Values["controller"].ToString();

            if(userSession != null)
            {
                Constants.THEME_COLOR =  user.GetUserThemeSettings(userSession);
            }

            if (ControllerName == "Login")
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller  
                if (userSession == null)
                    return;
                else if(actionName != "Logout")
                    context.Result = new RedirectResult("~/");

            }

            

            if (userSession == null && ControllerName.ToLower() !="api")
            {
                context.Result = new RedirectResult("~/Login");             
            }
            
        }
    }
}
