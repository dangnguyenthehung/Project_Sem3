using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Helper;
using Api.Security;
using Model.Models;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [RoutePrefix("api/login")]
    [CustomBasicAuthenticationFilter]
    public class LoginApiController : ApiController
    {
        private static readonly LoginApiHelper Helper = new LoginApiHelper();

        [HttpPost]
        [Route("customer")]
        public HttpResponseMessage CustomerLogin([FromBody] Login account)
        {
            var response = new HttpResponseMessage();

            if (account != null)
            {
                var result = Helper.CustomerLogin(account);

                if (result != null)
                {
                    //Customer dont have any special permission
                    result.Permissions = new List<int>();

                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

        [HttpPost]
        [Route("employee")]
        public HttpResponseMessage EmployeeLogin([FromBody] Login account)
        {
            var response = new HttpResponseMessage();

            if (account != null)
            {
                var result = Helper.EmployeeLogin(account);

                if (result != null)
                {
                    //Get lisst permission
                    Helper.GetEmployeePermission(ref result);

                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

        [HttpGet]
        [Route("findcustomer/{userName}")]
        public HttpResponseMessage FindCustomer(string userName)
        {
            var response = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(userName))
            {
                var result = Helper.FindCustomer(userName);

                if (result != null)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

        [HttpGet]
        [Route("findemployee/{userName}")]
        public HttpResponseMessage FindEmployee(string userName)
        {
            var response = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(userName))
            {
                var result = Helper.FindEmployee(userName);

                if (result != null)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }
    }
}
