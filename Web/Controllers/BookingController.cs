using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.Enum;
using Model.Models;
using Model.Security;
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
            var viewModel = new OrderViewModel();
            if (ModelState.IsValid)
            {
                if (SessionPersister.CustomerAccount != null)
                {
                    model.IdCustomer = SessionPersister.CustomerAccount.IdCustomer;
                    viewModel.Order = model;
                    SessionPersister.OrderInfomation = viewModel;

                    return RedirectToAction("Step2", "Booking");
                }
            }

            return View(viewModel);
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
            if (viewModel.ListIdTable.Any())
            {
                if (SessionPersister.OrderInfomation != null)
                {
                    viewModel.Order.IdCustomer = SessionPersister.OrderInfomation.Order.IdCustomer;
                    viewModel.Order.IdBranch = SessionPersister.OrderInfomation.Order.IdBranch;
                    viewModel.Order.BeginTime = SessionPersister.OrderInfomation.Order.BeginTime;
                    viewModel.ListAvailableTables = SessionPersister.OrderInfomation.ListAvailableTables;


                    var begin = new DateTime(viewModel.Order.BeginTime.Year, viewModel.Order.BeginTime.Month, viewModel.Order.BeginTime.Day, viewModel.BeginTime.Hour, viewModel.BeginTime.Minute, 0);

                    var end = new DateTime(viewModel.Order.BeginTime.Year, viewModel.Order.BeginTime.Month, viewModel.Order.BeginTime.Day, viewModel.EndTime.Hour, viewModel.EndTime.Minute, 0);

                    
                    viewModel.Order.BeginTime = begin;
                    viewModel.Order.EndTime = end;
                    viewModel.Order.NumberOfTable = viewModel.ListIdTable.Count;

                    //update info to viewModel

                    SessionPersister.OrderInfomation = viewModel;


                    return RedirectToAction("Preview");
                }
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

                GetDepositValue(ref viewModel);
                GetDepositToken(ref viewModel);

                ViewBag.Customer = CustomerModel.GetById(viewModel.Order.IdCustomer);

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
        public ActionResult Finish(OrderViewModel submitData)
        {
            if (SessionPersister.OrderInfomation != null)
            {
                var message = MessageConstants.OrderFail;

                var viewModel = SessionPersister.OrderInfomation;

                if (submitData.Order.IdBranch == viewModel.Order.IdBranch && submitData.Order.IdCustomer == viewModel.Order.IdCustomer && submitData.Order.BeginTime == viewModel.Order.BeginTime)
                {
                    viewModel.Order.OrderStatus = (int)Enums.OrderStatus.New;

                    var data = new OrderDTO()
                    {
                        Order = viewModel.Order,
                        ListIdTable = viewModel.ListIdTable
                    };
                    
                    var result = OrderModel.Insert(data);

                    if (result > 0)
                    {
                        message = MessageConstants.OrderSuccess;

                        return RedirectToAction("Index", "Message", new { message });
                    }

                }

                message = MessageConstants.OrderFail;
                return RedirectToAction("Index", "Message", new { message });
            }

            var url = HttpContext.Request.UrlReferrer;
            if (url != null)
            {
                return Redirect(url.ToString());
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Deposit(string token)
        {
            if (!string.IsNullOrEmpty(token) && token == SessionPersister.DepositToken)
            {
                if (SessionPersister.OrderInfomation != null)
                {

                    var viewModel = SessionPersister.OrderInfomation;
                    
                    viewModel.Order.OrderStatus = (int)Enums.OrderStatus.New;

                    var data = new OrderDTO()
                    {
                        Order = viewModel.Order,
                        ListIdTable = viewModel.ListIdTable
                    };

                    var result = OrderModel.Insert(data);

                    //Message
                    var message = MessageConstants.OrderFail;
                    if (result > 0)
                    {
                        message = MessageConstants.OrderSuccess;

                        return RedirectToAction("Index", "Message", new { message });
                    }

                    message = MessageConstants.OrderFail;
                    return RedirectToAction("Index", "Message", new { message });
                }
            }
            

            return RedirectToAction("Index", "Home");
        }


        private void GetDepositValue(ref OrderViewModel viewModel)
        {
            viewModel.Order.Deposit = 0;
            var listTable = viewModel.ListIdTable;
            foreach (var item in listTable)
            {
                var value = TableSingleTon.GetTableDepositFee(item);
                viewModel.Order.Deposit += value;
            }
        }

        private void GetDepositToken(ref OrderViewModel viewModel)
        {
            var baseStr = viewModel.Order.IdBranch + viewModel.Order.IdCustomer + viewModel.Order.BeginTime.ToLongDateString() + viewModel.Order.EndTime.ToLongDateString();
            viewModel.DepositToken = Encryptor.EncryptSHA1(baseStr);

            SessionPersister.DepositToken = viewModel.DepositToken;
        }
    }
}