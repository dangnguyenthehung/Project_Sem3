using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.Constants;
using Model.Models;
using Model.ViewModels;

namespace Web.Security
{
    public class SessionPersister
    {
        public static Customer CustomerAccount
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }

                var session = HttpContext.Current.Session[SessionConstants.CustomerAccount] as Customer;
                return session;
            }
            set
            {
                HttpContext.Current.Session[SessionConstants.CustomerAccount] = value;
            }
        }

        public static Employee EmployeeAccount
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }

                var session = HttpContext.Current.Session[SessionConstants.EmployeeAccount] as Employee;
                return session;
            }
            set
            {
                HttpContext.Current.Session[SessionConstants.EmployeeAccount] = value;
            }
        }

        public static OrderViewModel OrderInfomation
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }

                var session = HttpContext.Current.Session[SessionConstants.Order] as OrderViewModel;
                return session;
            }
            set
            {
                HttpContext.Current.Session[SessionConstants.Order] = value;
            }
        }
    }
}