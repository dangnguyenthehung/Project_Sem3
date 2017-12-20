using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers_Constants.Constants
{
    public class ApiUrls
    {
        private static string _apiUrl;

        public static void SetApiUrls(string url)
        {
            _apiUrl = url;
        }
        
        public class Login
        {
            private static readonly string BaseUrl = $"{_apiUrl}/login";

            public string Customer = $"{BaseUrl}/customer";
            public string Employee = $"{BaseUrl}/employee";

            public string FindCustomer = $"{BaseUrl}/findcustomer/";
            public string FindEmployee = $"{BaseUrl}/findemployee/";
        }


        public class RestaurantBranch
        {
            private static readonly string BaseUrl = $"{_apiUrl}/branch";

            public string GetAll = $"{BaseUrl}/getall";

            public string Find = $"{BaseUrl}/find/";
        }

        public class Table
        {
            private static readonly string BaseUrl = $"{_apiUrl}/table";

            public string Get_All = $"{BaseUrl}/get_list_table_all";
            public string Get_By_Id_Restaurant = $"{BaseUrl}/get_by_id_restaurant";
            public string Get_Table_Available = $"{BaseUrl}/get_table_available/";
            public string Get_List_TableType = $"{BaseUrl}/get_list_tabletype/";
        }

        public class Order
        {
            private static readonly string BaseUrl = $"{_apiUrl}/order";

            public string Insert = $"{BaseUrl}/insert";
            public string Verify = $"{BaseUrl}/verify";
            public string Get_By_Id = $"{BaseUrl}/get_by_id/";
            public string Get_List_Order_Table = $"{BaseUrl}/get_list_order_table/";
            public string Get_List_Order_By_Status = $"{BaseUrl}/get_list_order_by_status/";
            public string Get_All = $"{BaseUrl}/get_all/";
        }

        public class Customer
        {
            private static readonly string BaseUrl = $"{_apiUrl}/customer";

            public string Get_By_Id = $"{BaseUrl}/get_by_id/";
            
        }

        public class Employee
        {
            private static readonly string BaseUrl = $"{_apiUrl}/employee";

            public string Login = $"{BaseUrl}/login/";

        }

        public class Security
        {
            private static readonly string BaseUrl = $"{_apiUrl}/security";

            public string GetListRoleAndPermission = $"{BaseUrl}/get_list_role_and_permission";
            public string GetAccountListRoles = $"{BaseUrl}/get_account_list_roles/";
        }
    }
}
