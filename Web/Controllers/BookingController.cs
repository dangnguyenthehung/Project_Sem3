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
using Web.Security;
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
                SessionPersister.OrderInfomation = viewModel;

                return RedirectToAction("Step2", "Booking");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Step2()
        {
            if (SessionPersister.OrderInfomation != null)
            {
                var viewModel = SessionPersister.OrderInfomation;

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

                SessionPersister.OrderInfomation = viewModel;

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
            if (SessionPersister.OrderInfomation != null)
            {
                
                var begin = new DateTime(viewModel.OrderDate.Year, viewModel.OrderDate.Month, viewModel.OrderDate.Day, viewModel.BeginTime.Hour, viewModel.BeginTime.Minute,0);

                var end = new DateTime(viewModel.OrderDate.Year, viewModel.OrderDate.Month, viewModel.OrderDate.Day, viewModel.EndTime.Hour, viewModel.EndTime.Minute, 0);

                viewModel.Order.BeginTime = begin;
                viewModel.Order.EndTime = end;

                //update info to viewModel

                SessionPersister.OrderInfomation = viewModel;


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
            if (SessionPersister.OrderInfomation != null)
            {
                var viewModel = SessionPersister.OrderInfomation;
                
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
            if (SessionPersister.OrderInfomation != null)
            {
                var viewModel = SessionPersister.OrderInfomation;
                
                var data = new OrderDTO()
                {
                    Order = viewModel.Order,
                    ListIdTable = viewModel.ListIdTable
                };

                var result = OrderModel.Insert(data);

                var message = MessageConstants.OrderFail;
                if (result > 0)
                {
                    message = MessageConstants.OrderSuccess;
                    
                }

                return RedirectToAction("Index", "Message", new { message });
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