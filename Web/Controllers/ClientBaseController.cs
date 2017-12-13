using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Security;

namespace Web.Controllers
{
    public class ClientBaseController : Controller
    {
        public ClientBaseController()
        {
            //
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.isMobileDevice = Request.Browser.IsMobileDevice;
            string request = WebConfigurationManager.AppSettings["RootSite"];

            // Get current full Request URL
            if (Request.Url != null)
            {
                request = Request.Url.ToString();
            }
            
            // Check login State
            if (SessionPersister.CustomerAccount == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
            else
            {
                var taiKhoan = SessionPersister.CustomerAccount;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}