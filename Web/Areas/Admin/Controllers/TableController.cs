using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DTO;
using Model.Models;
using Model.ViewModels;
using Web.Models;
using Web.Security;
using Web.SingleTon;

namespace Web.Areas.Admin.Controllers
{
    public class TableController : AdminBaseController
    {
        // GET: Admin/Table
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Available(int id)
        {
            var viewModel = new OrderViewModel()
            {
                Order = new Orders() { IdBranch = id, BeginTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1)}
            };

            GetTableData(ref viewModel);

            return View(viewModel);
        }

        private void GetTableData(ref OrderViewModel viewModel)
        {
            var order = viewModel.Order;

            var tableFilter = new TableFilterDTO()
            {
                IdBranch = order.IdBranch,
                BranchAddress = BranchSingleTon.GetAddress(order.IdBranch),
                BeginTime = order.BeginTime,
                EndTime = order.EndTime
            };

            var table = TableModel.GetTableAvailable(tableFilter);

            //update info to viewModel
            viewModel.ListAvailableTables = table;

            SessionPersister.OrderInfomation = viewModel;
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


        public JsonResult GetTableAvailable(int idBranch, DateTime date, string beginTime, string endTime)
        {
            var beginStr = beginTime.Split(':');
            var endStr = endTime.Split(':');

            var begin = new DateTime(date.Year, date.Month, date.Day, int.Parse(beginStr[0]), int.Parse(beginStr[1]), 0);

            var end = new DateTime(date.Year, date.Month, date.Day, int.Parse(endStr[0]), int.Parse(endStr[1]), 0);

            var tableFilter = new TableFilterDTO()
            {
                IdBranch = idBranch,
                BranchAddress = BranchSingleTon.GetAddress(idBranch),
                BeginTime = begin,
                EndTime = end
            };

            var table = TableModel.GetTableAvailable(tableFilter);

            var result = table.GroupBy(t => t.IdTableType).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}