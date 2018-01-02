using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.Models;

namespace Web.Models
{
    public static class CustomerModel
    {
        private static readonly ApiUrls.Customer ApiUrl = new ApiUrls.Customer();
        private static readonly CustomerHelper Helper = new CustomerHelper();

        public static Customer GetById(int id)
        {
            var url = ApiUrl.Get_By_Id;

            return Helper.GetById(url, id);
        }

        public static Customer GetByUserName(string cmnd, string phone)
        {
            var url = ApiUrl.Get_By_UserName;

            return Helper.GetByUserName(url, cmnd, phone);
        }

        public static int Insert(Customer model)
        {
            var url = ApiUrl.Insert;

            return Helper.Insert(url, model);
        }
    }
}