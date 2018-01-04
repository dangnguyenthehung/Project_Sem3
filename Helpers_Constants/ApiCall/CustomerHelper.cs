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
        public Customer GetById(string apiUrl, int id)
        {
            return _Get_By_Id<Customer>(apiUrl, id);
        }

        public Customer GetByUserName(string apiUrl, string cmnd, string phone)
        {
            return _Get_By_Keyword_Multiple<Customer>(apiUrl, cmnd, phone);
        }

        public int Insert(string apiUrl, Customer model)
        {
            return _Insert(apiUrl, model);
        }
    }
}
