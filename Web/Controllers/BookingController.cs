using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.Models;
using Model.ViewModels;
using Web.Models;
using Web.SingleTon;

namespace Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Orders model)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new OrderViewModel()
                {
                    Order = model
                };
                Session[SessionConstants.Order] = viewModel;

                return RedirectToAction("Step2", "Booking");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Step2()
        {
            if (Session[SessionConstants.Order] != null)
            {
                var viewModel = (OrderViewModel)Session[SessionConstants.Order];

                var order = viewModel.Order;

                var tableFilter = new TableFilterDTO()
                {
                    IdBranch = order.IdBranch,
                    BranchAddress = BranchSingleTon.GetAddress(order.IdBranch),
                    BeginTime = order.BeginTime,
                    EndTime = order.BeginTime.AddDays(1)
                };

                var table = TableModel.GetTableAvailable(tableFilter);
                
                //update info to viewModel
                viewModel.ListAvailableTables = table;

                Session.Remove(SessionConstants.Order);
                Session[SessionConstants.Order] = viewModel;

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
        public ActionResult Step2(OrderViewModel viewModel)
        {
            if (Session[SessionConstants.Order] != null)
            {
                
                var begin = new DateTime(viewModel.OrderDate.Year, viewModel.OrderDate.Month, viewModel.OrderDate.Day, viewModel.BeginTime.Hour, viewModel.BeginTime.Minute,0);

                var end = new DateTime(viewModel.OrderDate.Year, viewModel.OrderDate.Month, viewModel.OrderDate.Day, viewModel.EndTime.Hour, viewModel.EndTime.Minute, 0);

                viewModel.Order.BeginTime = begin;
                viewModel.Order.EndTime = end;
                
                //update info to viewModel
                
                Session.Remove(SessionConstants.Order);
                Session[SessionConstants.Order] = viewModel;


                return RedirectToAction("Preview");
            }

            var url = HttpContext.Request.UrlReferrer;

            if (url != null)
            {
                return Redirect(url.ToString());
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Preview()
        {
            if (Session[SessionConstants.Order] != null)
            {
                var viewModel = (OrderViewModel)Session[SessionConstants.Order];
                
                return View(viewModel);
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
            if (Session[SessionConstants.Order] != null)
            {
                var viewModel = (OrderViewModel)Session[SessionConstants.Order];
                
                var data = new OrderDTO()
                {
                    Order = viewModel.Order,
                    ListIdTable = viewModel.ListIdTable
                };
                var result = OrderModel.Insert(data);



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