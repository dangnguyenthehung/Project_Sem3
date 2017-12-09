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
        private static readonly ApiUrls.DangNhap ApiUrl = new ApiUrls.DangNhap();
        private static readonly LoginHelper Helper = new LoginHelper();

        public static Account Login(Login accLogin)
        {
            if (accLogin == null)
            {
                return null;
            }
            var url = ApiUrl.Login;

            var result = Helper.Login(url, accLogin);

            return result;
        }

        public static Account GetAccountPermissions(ref Account account)
        {
            if (account == null)
            {
                return null;
            }

            account.Permissions = RolesSingleTon.GetPermissionsList(account.Roles);

            return account;
        }

        public static Account Find(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            
            var url = ApiUrl.Find;

            var result = Helper.Find(url, userName);

            return result;
        }
    }
}