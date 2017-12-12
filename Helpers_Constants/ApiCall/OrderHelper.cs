using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Models;

namespace Helpers_Constants.ApiCall
{
    public class OrderHelper : BaseHelper
    {
        public Orders GetById(string apiUrl, int id)
        {
            return _Get_By_Id<Orders>(apiUrl, id);
        }

        public List<Order_Table> GetListOrderTable(string apiUrl, int id)
        {
            return _Get_By_Id<List<Order_Table>>(apiUrl, id);
        }

        //order table
        public int Insert(string apiUrl, OrderDTO order)
        {
            return _Insert(apiUrl,order);
        }
    }
}
