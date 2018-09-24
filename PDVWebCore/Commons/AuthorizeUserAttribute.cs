using PDVWebCore.Areas.Admin.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDVWebCore.Commons
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string Role;

        public object Response { get; private set; }

        //public AuthorizeUserAttribute(params string[] values)
        //{ }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized)
            //{
            //    return false;
            //}

            string user = HttpContext.Current.Session["UserLoggedIn"] as string;
            if (user != null)
            {
                List<CustomerRole> userRoles = HttpContext.Current.Session["UserRoles"] as List<CustomerRole>;
                foreach (CustomerRole r in userRoles)
                    if (Role == r.RoleCode)
                        return true;
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string user = HttpContext.Current.Session["UserLoggedIn"] as string;
            if (user != null)
                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new
                                {
                                    area = "Admin",
                                    controller = "Home",
                                    action = "Index"
                                })
                            );
            else
                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new
                                {
                                    area = "Admin",
                                    controller = "Home",
                                    action = "Login"
                                })
                            );
        }
    }
}