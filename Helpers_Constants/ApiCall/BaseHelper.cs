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
        protected internal int _Insert<T>(string apiUrl, T model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

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
        }

        protected internal bool _Update<T>(string apiUrl, T model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

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
        }

        protected internal bool _Delete(string apiUrl, int id, int idTaiKhoanDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var urlParams = $"{id}/{idTaiKhoanDelete}";

                var response = client.DeleteAsync(urlParams).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
        
        protected internal T _Get<T>(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var response = client.GetAsync(client.BaseAddress).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                    return result;
                }

                return default(T);
            }
        }

        protected internal T _Get_By_Id<T>(string apiUrl, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var response = client.GetAsync(id.ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                    return result;
                }

                return default(T);
            }
        }
        
        protected internal T _Get_By_Keyword_Multiple<T>(string apiUrl, string param1, string param2)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var paramStr = $"{param1}/{param2}";

                var response = client.GetAsync(paramStr).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                    return result;
                }

                return default(T);
            }
        }
        protected internal T _Get_By_Keyword<T>(string apiUrl, string keyword)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var response = client.GetAsync(keyword).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                    return result;
                }

                return default(T);
            }
        }

        protected internal List<T> _Get_All<T>(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var response = client.GetAsync(client.BaseAddress).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);

                    return result;
                }

                return null;
            }
        }

        protected internal List<T> _Get_By_Id_Parent<T>(string apiUrl, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

                var response = client.GetAsync(id.ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);

                    return result;
                }

                return null;
            }
        }

        protected internal T _Get_By_Params_Object<T, Q>(string apiUrl, Q param)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);

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
        }
        

    }
}
