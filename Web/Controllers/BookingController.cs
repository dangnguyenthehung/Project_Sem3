using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.ViewModels;
using Web.Models;

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
        public ActionResult Index(BookingInfoDTO model)
        {
            if (ModelState.IsValid)
            {
                model.OrderDate = System.DateTime.Now;
                Session[SessionConstants.BookingInfo] = model;

                return RedirectToAction("Step2", "Booking");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Step2()
        {
            if (Session[SessionConstants.BookingInfo] != null)
            {
                var bookingInfo = (BookingInfoDTO)Session[SessionConstants.BookingInfo];

                var tableFilter = new TableFilterDTO()
                {
                    RestaurantId = bookingInfo.IdBranch,
                    BeginTime = bookingInfo.OrderDate,
                    EndTime = bookingInfo.OrderDate

                };
                var table = TableModel.GetTableAvailable(tableFilter);

                var viewModel = new BookingViewModel()
                {
                    BookingInfo = bookingInfo,
                    ListTables = table
                };

                return View(viewModel);
            }


            var url = HttpContext.Request.UrlReferrer;
            return Redirect(url.ToString());
        }
    }
}