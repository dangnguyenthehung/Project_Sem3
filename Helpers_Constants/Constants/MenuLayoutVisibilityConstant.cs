using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Functions;
using Model.Models;

namespace Helpers_Constants.Constants
{
    public class MenuLayoutVisibilityConstant
    {
        private static Employee _loginAccount = null;

        public _Order Order = new _Order();

        #region Modules

        public class _Order
        {
            public bool Any = false;
            
            public bool Get_New = false;
            public bool Get_Verified = false;
            public bool Get_Completed = false;
            public bool Get_Cancel = false;
            public bool Get_Refunded = false;
            public bool Insert = false;
            public bool Update = false;
            public bool Delete = false;
        }
        
        #endregion


        public void CheckMenuVisibilityState(Employee loginAccount)
        {
            if (loginAccount?.IdEmployee == null)
            {
                return;
            }
            _loginAccount = loginAccount;

            #region ModuleVisibilityState

            Order.Any = CheckModuleVisibility<PermissionConstants.Order>();
            
            #endregion

            #region ModuleActionVisibilityState
            
            Order.Get_New = CheckModuleActionVisibility(PermissionConstants.Order.Get_New);
            Order.Get_Verified = CheckModuleActionVisibility(PermissionConstants.Order.Get_Verified);
            Order.Get_Completed = CheckModuleActionVisibility(PermissionConstants.Order.Get_Completed);
            Order.Get_Cancel = CheckModuleActionVisibility(PermissionConstants.Order.Get_Cancel);
            Order.Get_Refunded = CheckModuleActionVisibility(PermissionConstants.Order.Get_Refunded);
            Order.Insert = CheckModuleActionVisibility(PermissionConstants.Order.Insert);
            Order.Update = CheckModuleActionVisibility(PermissionConstants.Order.Update);
            Order.Delete = CheckModuleActionVisibility(PermissionConstants.Order.Delete);
            
            #endregion

        }

        #region Function

        private bool CheckModuleVisibility<T>()
        {
            if (_loginAccount != null)
            {
                var temp = typeof(T).GetAllPublicConstantValues<string>();
                var permissionList = temp.Select(int.Parse).ToList();

                var accPermissions = _loginAccount.Permissions;
                if (accPermissions.Any(a => permissionList.Any(p => p == a)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckModuleActionVisibility(string permissionStr)
        {
            if (_loginAccount != null)
            {
                int.TryParse(permissionStr, out var permission);

                var accPermissions = _loginAccount.Permissions;
                if (accPermissions.Any(a => a == permission))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
