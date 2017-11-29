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
        private Account account;

        public MyPrincipal(Account acc)
        {
            if (acc != null)
            {
                account = acc;
                Identity = new GenericIdentity(account.UserName);
            }
            else
            {
                account = new Account();
            }
        }

        public bool IsInRole(string permissionStr)
        {
            int permission = int.Parse(permissionStr);
            var res = account.Permissions.Any(r => r == permission);

            return res;
        }

        public IIdentity Identity { get; }
    }
}