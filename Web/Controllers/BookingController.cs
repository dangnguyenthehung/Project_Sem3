using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.ViewModels;
using Web.Models;
using Web.SingleTon;

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
                var viewModel = new BookingViewModel()
                {
                    BookingInfo = model
                };
                Session[SessionConstants.Booking] = viewModel;

                return RedirectToAction("Step2", "Booking");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Step2()
        {
            if (Session[SessionConstants.Booking] != null)
            {
                var viewModel = (BookingViewModel)Session[SessionConstants.Booking];

                var bookingInfo = viewModel.BookingInfo;

                var tableFilter = new TableFilterDTO()
                {
                    IdBranch = bookingInfo.IdBranch,
                    BranchAddress = BranchSingleTon.GetAddress(bookingInfo.IdBranch),
                    BeginTime = bookingInfo.OrderDate,
                    EndTime = bookingInfo.OrderDate.AddDays(1)
                };

                var table = TableModel.GetTableAvailable(tableFilter);
                
                //update info to viewModel
                viewModel.ListAvailableTables = table;

                Session.Remove(SessionConstants.Booking);
                Session[SessionConstants.Booking] = viewModel;

                return View(viewModel);
            }
            
            var url = HttpContext.Request.UrlReferrer;
            if (url != null)
            {
                return Redirect(url.ToString());
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Step2(BookingDetailDTO details)
        {
            if (Session[SessionConstants.Booking] != null)
            {
                var viewModel = (BookingViewModel)Session[SessionConstants.Booking];

                var bookingInfo = viewModel.BookingInfo;

                var begin = new DateTime(details.OrderDate.Year, details.OrderDate.Month, details.OrderDate.Day, details.BeginTime.Hour, details.BeginTime.Minute,0);

                var end = new DateTime(details.OrderDate.Year, details.OrderDate.Month, details.OrderDate.Day, details.EndTime.Hour, details.EndTime.Minute, 0);

                details.BeginTime = begin;
                details.EndTime = end;


                //update info to viewModel
                viewModel.BookingDetail = details;

                Session.Remove(SessionConstants.Booking);
                Session[SessionConstants.Booking] = viewModel;


                return View("Finish");
            }


            var url = HttpContext.Request.UrlReferrer;

            if (url != null)
            {
                return Redirect(url.ToString());
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Finish()
        {
            if (Session[SessionConstants.Booking] != null)
            {
                var viewModel = (BookingViewModel)Session[SessionConstants.Booking];

                var bookingInfo = viewModel.BookingInfo;

                

                return View(viewModel);
            }

            var url = HttpContext.Request.UrlReferrer;
            if (url != null)
            {
                return Redirect(url.ToString());
            }

            return RedirectToAction("Index", "Home");
        }
    }
}