using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using Model.Functions;
using Model.Models;

namespace Api.Helper
{
    public class LoginApiHelper
    {
        public Model.Models.Customer CustomerLogin(Login account)
        {
            if (account == null)
            {
                return null;
            }

            using (var entities = new DatBanOnlineEntities())
            {
                try
                {
                    var result = entities.Get_Customer_By_Login(account.UserName, account.Password).SingleOrDefault();

                    var response = result.Cast<Model.Models.Customer>();

                    return response;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }

        public Model.Models.Employee EmployeeLogin(Login account)
        {
            if (account == null)
            {
                return null;
            }

            using (var entities = new DatBanOnlineEntities())
            {
                try
                {
                    var result = entities.Get_Employee_By_Login(account.UserName, account.Password).SingleOrDefault();

                    var response = result.Cast<Model.Models.Employee>();

                    return response;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }

        public void GetEmployeePermission(ref Model.Models.Employee account)
        {
            if (account == null)
            {
                return;
            }

            using (var entities = new DatBanOnlineEntities())
            {
                try
                {
                    
                    var listPermisson = entities.Get_List_Permissions_By_ID_Account(account.IdEmployee).ToList();

                    account.Permissions = listPermisson.Select(p => p.IdPermission).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public Model.Models.Customer FindCustomer(string userName)
        {
            return null;
        }

        public Model.Models.Employee FindEmployee(string userName)
        {
            return null;
        }
    }
}