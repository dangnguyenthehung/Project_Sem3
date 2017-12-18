using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModels;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        // GET: Admin/Booking
        public ActionResult Index()
        {
            var model = OrderModel.GetAll();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = OrderModel.GetById(id);

            return View(model);
        }

        public ActionResult Update(int id)
        {
            var model = OrderModel.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(BookingDetailsViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}