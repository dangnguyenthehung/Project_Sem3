using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        public AdminBaseController()
        {
            //
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.isMobileDevice = Request.Browser.IsMobileDevice;
            //string request = WebConfigurationManager.AppSettings["RootSite"];

            //// Get current full Request URL
            //if (Request.Url != null)
            //{
            //    request = Request.Url.ToString();
            //}

            // Check login State
            if (SessionPersister.EmployeeAccount == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index",
                    Area = "Admin"
                }));
            }
            else
            {
                //var account = SessionPersister.EmployeeAccount;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}