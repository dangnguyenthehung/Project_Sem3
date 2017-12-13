using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.Models;

namespace Web.Models
{
    public class LoginModel
    {
        private static readonly ApiUrls.Login ApiUrl = new ApiUrls.Login();
        private static readonly LoginHelper Helper = new LoginHelper();

        public static Customer CustomerLogin(Login accLogin)
        {
            if (accLogin == null)
            {
                return null;
            }
            var url = ApiUrl.Customer;

            var result = Helper.CustomerLogin(url, accLogin);

            return result;
        }
        
        public static Customer FindCustomer(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            
            var url = ApiUrl.FindCustomer;

            var result = Helper.FindCustomer(url, userName);

            return result;
        }

        public static Employee EmployeeLogin(Login accLogin)
        {
            if (accLogin == null)
            {
                return null;
            }
            var url = ApiUrl.Employee;

            var result = Helper.EmployeeLogin(url, accLogin);

            return result;
        }

        public static Employee FindEmployee(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            var url = ApiUrl.FindEmployee;

            var result = Helper.FindEmployee(url, userName);

            return result;
        }
    }
}