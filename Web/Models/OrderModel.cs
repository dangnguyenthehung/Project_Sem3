using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.Models;

namespace Web.Models
{
    public static class OrderModel
    {
        private static readonly ApiUrls.Order ApiUrl = new ApiUrls.Order();
        private static readonly OrderHelper Helper = new OrderHelper();

        public static Orders GetById(int id)
        {
            var url = ApiUrl.Get_By_Id;

            return Helper.GetById(url, id);
        }

        public static List<Order_Table> GetListOrderTable(int id)
        {
            var url = ApiUrl.Get_List_Order_Table;

            return Helper.GetListOrderTable(url, id);
        }

        public static int Insert(OrderDTO order)
        {
            var url = ApiUrl.Insert;

            return Helper.Insert(url, order);
        }
    }
}