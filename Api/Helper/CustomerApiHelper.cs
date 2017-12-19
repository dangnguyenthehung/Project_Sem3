using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using Model.Functions;

namespace Api.Helper
{
    public class CustomerApiHelper
    {
        public Model.Models.Customer GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Get_Customer_By_Id(id).SingleOrDefault();

                        var result = response?.Cast<Model.Models.Customer>();

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