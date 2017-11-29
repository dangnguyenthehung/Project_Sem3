using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}