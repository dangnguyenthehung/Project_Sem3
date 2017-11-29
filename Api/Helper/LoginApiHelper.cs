using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Models;

namespace Api.Helper
{
    public class LoginApiHelper
    {
        public Account Login(Login account)
        {
            if (account == null)
            {
                return null;
            }

            //using (var entities = new ())
            //{
            //    try
            //    {
            //        var result = entities.

            //        var response = result.Cast<Account>();

            //        return response;
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}
            return null;
        }

        public void GetAccountRoles(ref Account account)
        {
            if (account == null)
            {
                return;
            }

            //using (var entities = )
            //{
            //    try
            //    {
            //        //map roles mới get được vào tài khoản
            //        //account.Roles = entities.QLSX_Get_DanhSach_Roles_By_ID_TaiKhoan(account.ID_TaiKhoan).Select(r => r.ID_Role).ToList();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}
        }

        public Account Find(string userName)
        {
            return null;
        }
    }
}