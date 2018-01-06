using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.Models;
using Web.Security;

namespace Web.Models
{
    public static class OrderModel
    {
        private static readonly ApiUrls.Order ApiUrl = new ApiUrls.Order();
        private static readonly OrderHelper Helper = new OrderHelper();

        public static Orders GetById(int id)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_By_Id;

            return Helper.GetById(token, url, id);
        }

        public static List<Orders> GetByOrderStatus(int status)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_List_Order_By_Status;

            return Helper.GetByOrderStatus(token, url, status);
        }

        public static List<Orders> GetAll()
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_All;

            return Helper.GetAll(token, url);
        }

        public static List<Order_Table> GetListOrderTable(int id)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_List_Order_Table;

            return Helper.GetListOrderTable(token, url, id);
        }

        public static int Insert(OrderDTO order)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Insert;

            return Helper.Insert(token, url, order);
        }

        public static bool Verify(Orders order)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Verify;

            return Helper.Verify(token, url, order);
        }

        public static bool Update(Orders order)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Update;

            return Helper.Update(token, url, order);
        }
    }
}