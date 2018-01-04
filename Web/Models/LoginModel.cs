using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Helpers_Constants.Utilities;
using Model.Models;
using Web.Security;

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
            var tempToken = Utilities.CreateLoginToken(new Login()
            {
                UserName = WebConfigurationManager.AppSettings["ApiUserName"],
                Password = WebConfigurationManager.AppSettings["ApiPassword"]
            });
            var result = Helper.CustomerLogin(tempToken, url, accLogin);

            return result;
        }
        
        public static Customer FindCustomer(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            var token = SessionPersister.ApiToken;
            var url = ApiUrl.FindCustomer;

            var result = Helper.FindCustomer(token, url, userName);

            return result;
        }
        
        public static Employee EmployeeLogin(Login accLogin)
        {
            if (accLogin == null)
            {
                return null;
            }

            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Employee;

            var result = Helper.EmployeeLogin(token, url, accLogin);

            return result;
        }

        public static Employee FindEmployee(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            var token = SessionPersister.ApiToken;
            var url = ApiUrl.FindEmployee;

            var result = Helper.FindEmployee(token, url, userName);

            return result;
        }
    }
}