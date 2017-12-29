using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using Model.Functions;
using Customer = Model.Models.Customer;

namespace Api.Helper
{
    public class CustomerApiHelper
    {
        public Customer GetById(int id)
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

        public int Insert(Customer model)
        {
            try
            {
                if (model != null)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Insert_Customer(model.CMND, model.FullName, model.Phone, model.Address, model.Password).SingleOrDefault();

                        if (response?.IdCustomer != null)
                        {
                            return response.IdCustomer;
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}