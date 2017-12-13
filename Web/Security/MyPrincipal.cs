using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Model.Models;

namespace Web.Security
{
    public class MyPrincipal : IPrincipal
    {
        private Employee Employee;

        public MyPrincipal(Employee acc)
        {
            if (acc != null)
            {
                Employee = acc;
                Identity = new GenericIdentity(Employee.StaffId);
            }
            else
            {
                Employee = new Employee();
            }
        }

        public bool IsInRole(string permissionStr)
        {
            int permission = int.Parse(permissionStr);
            var res = Employee.Permissions.Any(r => r == permission);

            return res;
        }

        public IIdentity Identity { get; }
    }
}