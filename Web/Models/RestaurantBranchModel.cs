using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.Models;

namespace Web.Models
{
    public static class RestaurantBranchModel
    {
        private static readonly ApiUrls.RestaurantBranch ApiUrl = new ApiUrls.RestaurantBranch();
        private static readonly RestaurantBranchHelper Helper = new RestaurantBranchHelper();

        public static List<RestaurantBranch> GetAll()
        {
            var url = ApiUrl.GetAll;

            return Helper.GetAll(url);
        }
    }
}