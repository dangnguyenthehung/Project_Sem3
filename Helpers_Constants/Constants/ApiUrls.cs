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

        public class Security
        {
            private static readonly string BaseUrl = $"{_apiUrl}/security";

            public string GetListRoleAndPermission = $"{BaseUrl}/get_list_role_and_permission";
            public string GetAccountListRoles = $"{BaseUrl}/get_account_list_roles/";
        }
    }
}
