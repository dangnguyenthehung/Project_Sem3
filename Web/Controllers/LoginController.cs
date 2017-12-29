﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers_Constants.Constants;
using Model.Models;
using Model.Security;
using Web.Models;
using Web.Security;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (SessionPersister.CustomerAccount != null)
            {
                SessionPersister.CustomerAccount = null;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Encryptor.EncryptSHA1(model.Password);
                var loginAccount = LoginModel.CustomerLogin(model);
                
                if (loginAccount == null)
                {
                    ViewBag.error = MessageConstants.LoginFail;
                    return View(model);
                }
                else
                {
                    //Save login info to session
                    SessionPersister.CustomerAccount = loginAccount;
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult SignUp()
        {
            if (SessionPersister.CustomerAccount != null)
            {
                SessionPersister.CustomerAccount = null;
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Customer model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Encryptor.EncryptSHA1(model.Password);
                var accountId = CustomerModel.Insert(model);
                
                if (accountId <= 0)
                {
                    ViewBag.error = MessageConstants.InsertFail;
                    return View(model);
                }
                else
                {
                    //Save login info to session
                    var loginAccount = CustomerModel.GetById(accountId);
                    if(loginAccount != null)
                    {
                        SessionPersister.CustomerAccount = loginAccount;
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}