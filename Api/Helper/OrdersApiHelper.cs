using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Context.Database;
using Model.Functions;
using Model.Models;

namespace Api.Helper
{
    public class OrdersApiHelper
    {
        public int Insert(Orders order)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    var result = context.Insert_Order(order.IdCustomer, order.NumberOfTable, order.NumberOfCustomer,
                        order.IdBranch, order.BeginTime, order.EndTime, order.OrderStatus, order.Description).SingleOrDefault();

                    if (result != null)
                    {
                        return result.IdOrder;
                    }

                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                
            }
        }

        public bool Insert_Order_Table(DataTable table)
        {
            try
            {
                using (var context = new DatBanOnlineEntities())
                {
                    var param = new SqlParameter("@OrderTableTableType", table)
                    {
                        TypeName = "dbo.OrderTableTableType"
                    };
                    object[] sqlParams =
                    {
                        param
                    };

                    var res = context.Database.ExecuteSqlCommand("Insert_Order_Table @OrderTableTableType", sqlParams);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Orders GetById(int id)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    if (id > 0)
                    {
                        var result = context.Get_Order(id).SingleOrDefault();

                        return result?.Cast<Orders>();
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Model.Models.Order_Table> GetByIdOrder(int id)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    if (id > 0)
                    {
                        var response = context.Get_List_Order_Table(id).ToList();

                        var result = response.Select(p => p.Cast<Model.Models.Order_Table>()).ToList();
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
}