using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.DTO;
using Web.Models;

namespace Web
{
    public class RolesSingleTon
    {
        private RolesSingleTon()
        {
            //
        }

        private static List<RolesMapping> ListRoles = null;

        private RolesSingleTon _rolesSingleTon = new RolesSingleTon();

        private static void GetData()
        {
            ListRoles = SecurityModel.Get_ListRoles_And_Permission();
        }

        public List<RolesMapping> GetRolesAndPermission()
        {
            if (ListRoles == null)
            {
                GetData();
            }

            return ListRoles;
        }

        public static List<int> GetPermissionsList(List<int> roleList)
        {
            if (ListRoles == null)
            {
                GetData();
            }

            if (roleList == null)
            {
                return new List<int>();
            }

            var listPermission = ListRoles?.Where(p => roleList.Contains(p.IdRole)).Select(p => p.IdPermission).Distinct().ToList();

            return listPermission;
        }

    }
}