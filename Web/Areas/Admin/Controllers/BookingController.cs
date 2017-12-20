using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Enum;
using Model.Models;
using Model.ViewModels;
using Web.Models;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    public class BookingController : AdminBaseController
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

        public ActionResult Verify(int id)
        {
            if (SessionPersister.EmployeeAccount != null)
            {
                var order = new Orders()
                {
                    IdOrder = id,
                    OrderStatus = (int)Enums.OrderStatus.Verified,
                    IdEmployee_Verify = SessionPersister.EmployeeAccount.IdEmployee
                };

                var result = OrderModel.Verify(order);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }


            return RedirectToAction("Index");
        }
    }
}