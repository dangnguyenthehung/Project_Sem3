using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Web.Models;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (SessionPersister.EmployeeAccount != null)
            {
                SessionPersister.EmployeeAccount = null;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                var employeeAccount = LoginModel.EmployeeLogin(model);

                if (employeeAccount == null)
                {
                    ViewBag.error = "Invalid";
                    return View(model);
                }
                else
                {
                    //Save login info to session
                    SessionPersister.EmployeeAccount = employeeAccount;
                    //Session[SessionConstants.LoginAccountName] = result.HoTen;

                    //DangNhapModel.GetAccountPermissions(ref adminAccount);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}