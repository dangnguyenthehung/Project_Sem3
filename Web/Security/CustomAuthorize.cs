using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Security
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        //Set custom attribute
        public string Permission { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string permission = Permission;
            if (SessionPersister.EmployeeAccount == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Login"
                }));

            }
            else
            {
                var acc = SessionPersister.EmployeeAccount;

                var principal = new MyPrincipal(acc);

                if (!principal.IsInRole(permission))
                {
                    if (filterContext.IsChildAction)
                    {
                        filterContext.Result = new PartialViewResult()
                        {
                            ViewName = "_Partial_UnAuthorize"
                        };
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Index",
                            controller = "UnAuthorize"
                        }));
                    }
                }
            }
        }
    }
}