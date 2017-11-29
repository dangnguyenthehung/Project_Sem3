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
    public class LoginHelper
    {
        public Account Login(string apiUrl, Login account)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var obj = JsonConvert.SerializeObject(account);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(obj, Encoding.UTF8, "application/json");

                var response = client.PostAsync(client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Account>(response.Content.ReadAsStringAsync().Result);
                    return result;
                }

                return null;
            }
        }

        public Account Find(string apiUrl, string userName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var response = client.GetAsync(userName).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Account>(response.Content.ReadAsStringAsync().Result);
                    return result;
                }

                return null;
            }
        }
    }
}
