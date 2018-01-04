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
        public Customer CustomerLogin(string token, string apiUrl, Login account)
        {
            return _Get_By_Params_Object<Customer, Login>(token, apiUrl, account);
        }

        public Customer FindCustomer(string token, string apiUrl, string userName)
        {
            return _Get_By_Keyword<Customer>(token, apiUrl, userName);
        }

        public Employee EmployeeLogin(string token, string apiUrl, Login account)
        {
            return _Get_By_Params_Object<Employee, Login>(token, apiUrl, account);
        }

        public Employee FindEmployee(string token, string apiUrl, string userName)
        {
            return _Get_By_Keyword<Employee>(token, apiUrl, userName);
        }

    }
}
