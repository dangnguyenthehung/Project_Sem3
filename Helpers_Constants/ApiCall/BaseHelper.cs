using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helpers_Constants.ApiCall
{
    public class BaseHelper
    {
        protected internal int _Insert<T>(string token, string apiUrl, T model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var obj = JsonConvert.SerializeObject(model);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(obj, Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return 0;
        }

        protected internal bool _Update<T>(string token, string apiUrl, T model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var obj = JsonConvert.SerializeObject(model);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(obj, Encoding.UTF8, "application/json");

            var response = client.PutAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        protected internal bool _Delete(string token, string apiUrl, int id, int idTaiKhoanDelete)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var urlParams = $"{id}/{idTaiKhoanDelete}";

            var response = client.DeleteAsync(urlParams).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }

        protected internal T _Get<T>(string token, string apiUrl)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return default(T);

        }

        protected internal T _Get_By_Id<T>(string token, string apiUrl, int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var response = client.GetAsync(id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return default(T);

        }

        protected internal T _Get_By_Keyword_Multiple<T>(string token, string apiUrl, string param1, string param2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var paramStr = $"{param1}/{param2}";

            var response = client.GetAsync(paramStr).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return default(T);

        }
        protected internal T _Get_By_Keyword<T>(string token, string apiUrl, string keyword)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var response = client.GetAsync(keyword).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return default(T);

        }

        protected internal List<T> _Get_All<T>(string token, string apiUrl)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return null;

        }

        protected internal List<T> _Get_By_Id_Parent<T>(string token, string apiUrl, int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var response = client.GetAsync(id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return null;

        }

        protected internal T _Get_By_Params_Object<T, Q>(string token, string apiUrl, Q param)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            AddAuthenticationHeader(ref client, token);

            var obj = JsonConvert.SerializeObject(param);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(obj, Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return default(T);

        }

        //function
        private void AddAuthenticationHeader(ref HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var data = Encoding.ASCII.GetBytes(token);
            var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(data));
            client.DefaultRequestHeaders.Authorization = header;
        }
    }
}
