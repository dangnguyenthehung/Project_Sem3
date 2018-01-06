using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Helpers_Constants.Constants;
using Helpers_Constants.Utilities;
using Model.Models;
using Model.Security;
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
            //Check menu visibility
            var menuLayoutVisibility = new MenuLayoutVisibilityConstant();
            menuLayoutVisibility.CheckMenuVisibilityState(null);

            SessionPersister.MenuLayoutVisibility = menuLayoutVisibility;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Encryptor.EncryptSHA1(model.Password);
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
                    SessionPersister.ApiToken = Utilities.CreateLoginToken(new Login()
                    {
                        UserName = WebConfigurationManager.AppSettings["ApiUserName"],
                        Password = WebConfigurationManager.AppSettings["ApiPassword"]
                    });

                    //Check menu visibility
                    var menuLayoutVisibility = new MenuLayoutVisibilityConstant();
                    menuLayoutVisibility.CheckMenuVisibilityState(employeeAccount);

                    SessionPersister.MenuLayoutVisibility = menuLayoutVisibility;
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            if (SessionPersister.EmployeeAccount != null)
            {
                SessionPersister.EmployeeAccount = null;
            }
            //Check menu visibility
            var menuLayoutVisibility = new MenuLayoutVisibilityConstant();
            menuLayoutVisibility.CheckMenuVisibilityState(null);

            SessionPersister.MenuLayoutVisibility = menuLayoutVisibility;

            return RedirectToAction("Index","Login");
        }
    }
}