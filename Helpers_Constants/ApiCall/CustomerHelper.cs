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

        public int Insert(string apiUrl, Customer model)
        {
            return _Insert(apiUrl, model);
        }
    }
}
