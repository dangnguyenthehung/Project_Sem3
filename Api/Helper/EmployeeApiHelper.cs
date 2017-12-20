using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using Model.Functions;
using Model.Models;

namespace Api.Helper
{
    public class EmployeeApiHelper
    {
        public Model.Models.Employee Login(Login account)
        {
            try
            {
                if (account != null)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Get_Employee_By_Login(account.UserName, account.Password).SingleOrDefault();

                        var result = response?.Cast<Model.Models.Employee>();

                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}