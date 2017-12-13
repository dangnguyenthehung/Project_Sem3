using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Model.Models;

namespace Helpers_Constants.ApiCall
{
    public class LoginHelper : BaseHelper
    {
        public Customer CustomerLogin(string apiUrl, Login account)
        {
            return _Get_By_Params_Object<Customer, Login>(apiUrl, account);
        }

        public Customer FindCustomer(string apiUrl, string userName)
        {
            return _Get_By_Keyword<Customer>(apiUrl, userName);
        }

        public Employee EmployeeLogin(string apiUrl, Login account)
        {
            return _Get_By_Params_Object<Employee, Login>(apiUrl, account);
        }

        public Employee FindEmployee(string apiUrl, string userName)
        {
            return _Get_By_Keyword<Employee>(apiUrl, userName);
        }

    }
}
