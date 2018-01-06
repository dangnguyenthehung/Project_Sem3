using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: UnAuthorize
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}