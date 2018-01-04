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
    public static class RestaurantBranchModel
    {
        private static readonly ApiUrls.RestaurantBranch ApiUrl = new ApiUrls.RestaurantBranch();
        private static readonly RestaurantBranchHelper Helper = new RestaurantBranchHelper();

        public static List<RestaurantBranch> GetAll()
        {
            var tempToken = Utilities.CreateLoginToken(new Login()
            {
                UserName = WebConfigurationManager.AppSettings["ApiUserName"],
                Password = WebConfigurationManager.AppSettings["ApiPassword"]
            });
            var url = ApiUrl.GetAll;

            return Helper.GetAll(tempToken, url);
        }
    }
}