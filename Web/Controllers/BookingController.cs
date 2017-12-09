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
                    EndTime = bookingInfo.OrderDate.AddDays(1)

                };
                var table = TableModel.GetTableAvailable(tableFilter);

                var viewModel = new BookingViewModel()
                {
                    BookingInfo = bookingInfo,
                    ListAvailableTables = table
                };

                return View(viewModel);
            }


            var url = HttpContext.Request.UrlReferrer;
            return Redirect(url.ToString());
        }

        [HttpPost]
        public ActionResult Step2(BookingDetailDTO details)
        {
            if (Session[SessionConstants.BookingInfo] != null)
            {
                var bookingInfo = (BookingInfoDTO)Session[SessionConstants.BookingInfo];
                var begin = new DateTime(details.OrderDate.Year, details.OrderDate.Month, details.OrderDate.Day, details.BeginTime.Hour, details.BeginTime.Minute,0);

                var end = new DateTime(details.OrderDate.Year, details.OrderDate.Month, details.OrderDate.Day, details.EndTime.Hour, details.EndTime.Minute, 0);

                details.BeginTime = begin;
                details.EndTime = end;

                var viewModel = new BookingViewModel()
                {
                    BookingInfo = bookingInfo,
                    BookingDetail = details
                };

                return View("Finish");
            }


            var url = HttpContext.Request.UrlReferrer;
            return Redirect(url.ToString());
        }
    }
}