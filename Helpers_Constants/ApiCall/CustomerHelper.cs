using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Helpers_Constants.ApiCall
{
    public class CustomerHelper : BaseHelper
    {
        public Customer GetById(string token, string apiUrl, int id)
        {
            return _Get_By_Id<Customer>(token, apiUrl, id);
        }

        public Customer GetByUserName(string token, string apiUrl, string cmnd, string phone)
        {
            return _Get_By_Keyword_Multiple<Customer>(token, apiUrl, cmnd, phone);
        }

        public int Insert(string token, string apiUrl, Customer model)
        {
            return _Insert(token, apiUrl, model);
        }
    }
}
