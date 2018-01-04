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
using Newtonsoft.Json;
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

                GetStep2Data(ref viewModel);

                return View(viewModel);
            }
            
            //var url = HttpContext.Request.UrlReferrer;
            //if (url != null)
            //{
            //    return Redirect(url.ToString());
            //}

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Step2(OrderViewModel viewModel)
        {
            if (SessionPersister.OrderInfomation != null)
            {
                if (viewModel.ListIdTable != null && viewModel.ListIdTable.Any())
                {
                    if (viewModel.Order.NumberOfCustomer <= 20)
                    {
                        viewModel.Order.IdCustomer = SessionPersister.OrderInfomation.Order.IdCustomer;
                        viewModel.Order.IdBranch = SessionPersister.OrderInfomation.Order.IdBranch;
                        viewModel.Order.BeginTime = SessionPersister.OrderInfomation.Order.BeginTime;
                        viewModel.ListAvailableTables = SessionPersister.OrderInfomation.ListAvailableTables;

                        var beginStr = viewModel.BeginTime.Split(':');
                        var endStr = viewModel.EndTime.Split(':');

                        var begin = new DateTime(viewModel.Order.BeginTime.Year, viewModel.Order.BeginTime.Month, viewModel.Order.BeginTime.Day, int.Parse(beginStr[0]), int.Parse(beginStr[1]), 0);

                        var end = new DateTime(viewModel.Order.BeginTime.Year, viewModel.Order.BeginTime.Month, viewModel.Order.BeginTime.Day, int.Parse(endStr[0]), int.Parse(endStr[1]), 0);


                        viewModel.Order.BeginTime = begin;
                        viewModel.Order.EndTime = end;
                        viewModel.Order.NumberOfTable = viewModel.ListIdTable.Count;

                        //update info to viewModel

                        SessionPersister.OrderInfomation = viewModel;


                        return RedirectToAction("Preview");
                    }
                    else
                    {
                        viewModel.Order = SessionPersister.OrderInfomation.Order;

                        GetStep2Data(ref viewModel);

                        ModelState.AddModelError("", MessageConstants.OverMaximumCustomer);

                        return View(viewModel);
                    }
                }
                else
                {
                    viewModel.Order = SessionPersister.OrderInfomation.Order;

                    GetStep2Data(ref viewModel);

                    ModelState.AddModelError("", MessageConstants.NoneSelectTable);

                    return View(viewModel);
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

                    if (result > 0)
                    {
                        return RedirectToAction("Finish", "Booking");
                    }

                    var message = MessageConstants.OrderFail;
                    return RedirectToAction("Index", "Message", new { message });
                }
            }
            

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Finish()
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

        // Function
        private void GetStep2Data(ref OrderViewModel viewModel)
        {
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

        public JsonResult GetEndTime(string beginTime)
        {
            var listGioEnd = new List<string>()
            {
                "10:00",
                "10:30",
                "11:00",
                "11:30",
                "12:00",
                "12:30",
                "13:00",
                "13:30",
                "14:00",
                "14:30",
                "15:00",
                "15:30",
                "16:00",
                "16:30",
                "17:00",
                "17:30",
                "18:00",
                "18:30",
                "19:00",
                "19:30",
                "20:00",
                "20:30",
                "21:00",
                "21:30",
                "22:00",
                "22:30",
                "23:00",
                "23:30",
                "24:00"
            };
            var beginIndex = listGioEnd.IndexOf(beginTime) + 2;
            listGioEnd.RemoveRange(0, beginIndex);
            return Json(listGioEnd, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTableAvailable(string beginTime, string endTime)
        {
            var viewModel = SessionPersister.OrderInfomation;

            var beginStr = beginTime.Split(':');
            var endStr = endTime.Split(':');

            var begin = new DateTime(viewModel.Order.BeginTime.Year, viewModel.Order.BeginTime.Month, viewModel.Order.BeginTime.Day, int.Parse(beginStr[0]), int.Parse(beginStr[1]), 0);

            var end = new DateTime(viewModel.Order.BeginTime.Year, viewModel.Order.BeginTime.Month, viewModel.Order.BeginTime.Day, int.Parse(endStr[0]), int.Parse(endStr[1]), 0);

            var tableFilter = new TableFilterDTO()
            {
                IdBranch = viewModel.Order.IdBranch,
                BranchAddress = BranchSingleTon.GetAddress(viewModel.Order.IdBranch),
                BeginTime = begin,
                EndTime = end
            };

            var table = TableModel.GetTableAvailable(tableFilter);
            var result = new List<List<Table>>();

            var listType = TableTypeSingleTon.GetListTypes();

            foreach (var type in listType)
            {
                var temp = table.Where(t => t.IdTableType == type.Id_Table_Type).ToList();
                
                result.Add(temp);
            }

            //var result = table.GroupBy(t => t.IdTableType).ToList();
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}