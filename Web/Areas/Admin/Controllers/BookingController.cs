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
            if (id > 0)
            {
                var order = OrderModel.GetById(id);
                if (order.IdCustomer > 0)
                {
                    var customer = CustomerModel.GetById(order.IdCustomer);

                    var viewModel = new BookingDetailsViewModel()
                    {
                        Order = order,
                        Customer = customer
                    };

                    return View(viewModel);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var order = OrderModel.GetById(id);
            var customer = CustomerModel.GetById(order.IdCustomer);

            var viewModel = new BookingDetailsViewModel()
            {
                Order = order,
                Customer = customer
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(BookingDetailsViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}