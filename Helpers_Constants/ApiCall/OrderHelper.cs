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
        public Orders GetById(string token, string apiUrl, int id)
        {
            return _Get_By_Id<Orders>(token, apiUrl, id);
        }

        public List<Orders> GetAll(string token, string apiUrl)
        {
            return _Get_All<Orders>(token, apiUrl);
        }

        public List<Orders> GetByOrderStatus(string token, string apiUrl, int orderStatus)
        {
            return _Get_By_Id<List<Orders>>(token, apiUrl, orderStatus);
        }
        
        public bool Verify(string token, string apiUrl, Orders order)
        {
            return _Update(token, apiUrl, order);
        }

        public bool Update(string token, string apiUrl, Orders order)
        {
            return _Update(token, apiUrl, order);
        }

        //order table
        public List<Order_Table> GetListOrderTable(string token, string apiUrl, int id)
        {
            return _Get_By_Id<List<Order_Table>>(token, apiUrl, id);
        }

        public int Insert(string token, string apiUrl, OrderDTO order)
        {
            return _Insert(token, apiUrl,order);
        }
    }
}
