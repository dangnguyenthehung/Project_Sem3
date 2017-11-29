using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.DTO;

namespace Web.Models
{
    public class SecurityModel
    {
        private static readonly ApiUrls.Security ApiUrl = new ApiUrls.Security();
        private static readonly SecurityHelper Helper = new SecurityHelper();

        public static List<RolesMapping> Get_ListRoles_And_Permission()
        {
            var url = ApiUrl.GetListRoleAndPermission;

            return Helper.Get_ListRoles_And_Permission(url);
        }
    }
}