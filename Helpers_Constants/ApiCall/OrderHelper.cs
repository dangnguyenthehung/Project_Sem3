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

        public List<Orders> GetAll(string apiUrl)
        {
            return _Get_All<Orders>(apiUrl);
        }

        public List<Orders> GetByOrderStatus(string apiUrl, int orderStatus)
        {
            return _Get_By_Id<List<Orders>>(apiUrl, orderStatus);
        }
        
        public bool Verify(string apiUrl, Orders order)
        {
            return _Update(apiUrl, order);
        }

        //order table
        public List<Order_Table> GetListOrderTable(string apiUrl, int id)
        {
            return _Get_By_Id<List<Order_Table>>(apiUrl, id);
        }

        public int Insert(string apiUrl, OrderDTO order)
        {
            return _Insert(apiUrl,order);
        }
    }
}
