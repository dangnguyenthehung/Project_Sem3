using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DTO;

namespace Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Step2(BookingInfoDTO model)
        {
            if (ModelState.IsValid)
            {
                //
                
            }
            return View();
        }
    }
}