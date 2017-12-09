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

        public class DangNhap
        {
            private static readonly string BaseUrl = $"{_apiUrl}/login";

            public string Login = $"{BaseUrl}/submit";
            public string Find = $"{BaseUrl}/find/";
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

            public string Get_By_Id_Restaurant = $"{BaseUrl}/get_by_id_restaurant";

            public string Get_Table_Available = $"{BaseUrl}/get_table_available/";
        }

        public class Security
        {
            private static readonly string BaseUrl = $"{_apiUrl}/security";

            public string GetListRoleAndPermission = $"{BaseUrl}/get_list_role_and_permission";
            public string GetAccountListRoles = $"{BaseUrl}/get_account_list_roles/";
        }
    }
}
