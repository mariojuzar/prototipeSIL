using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PrototipeSIL.DAL;

namespace PrototipeSIL.Models
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        SILDBEntities db = new SILDBEntities();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorized = false;

            if (httpContext.Session["username"] != null)
            {
                if (Roles.ToString() != "")
                {
                    if (httpContext.Session["Role"].ToString().Equals("Super Admin") ||
                        httpContext.Session["Role"].ToString().Equals("Manager")) authorized = true;
                    else
                    {
                        authorized = false;
                    }
                }
                else
                {
                    authorized = true;
                }
            }
            if (!authorized)
            {
                // The user is not authorized => no need to go any further
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var routeValues = new RouteValueDictionary(new
            {
                controller = "Login",
                action = "Index",
            });
            filterContext.Result = new RedirectToRouteResult(routeValues);
        }

    }
}