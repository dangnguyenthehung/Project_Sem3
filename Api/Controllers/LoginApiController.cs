using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Helper;
using Model.Models;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginApiController : ApiController
    {
        private static readonly LoginApiHelper Helper = new LoginApiHelper();

        [HttpPost]
        [Route("submit")]
        public HttpResponseMessage Login([FromBody] Login account)
        {
            var response = new HttpResponseMessage();

            if (account != null)
            {
                var result = Helper.Login(account);

                if (result != null)
                {
                    //Login success, get account roles
                    Helper.GetAccountRoles(ref result);

                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

        [HttpGet]
        [Route("find/{userName}")]
        public HttpResponseMessage Find(string userName)
        {
            var response = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(userName))
            {
                Account result = Helper.Find(userName);

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
