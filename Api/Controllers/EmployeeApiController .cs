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
    [RoutePrefix("api/employee")]
    public class EmployeeApiController : ApiController
    {
        private static readonly EmployeeApiHelper Helper = new EmployeeApiHelper();

        //[Route("login/")]
        //[HttpPost]
        //public HttpResponseMessage Login([FromBody] Login account)
        //{
        //    var response = new HttpResponseMessage();

        //    var data = Helper.Login(account);

        //    if (data != null)
        //    {
        //        response.StatusCode = HttpStatusCode.OK;
        //        response.Content = new StringContent(JsonConvert.SerializeObject(data));
        //        return response;
        //    }
            
        //    response.StatusCode = HttpStatusCode.BadRequest;
        //    return response;
        //}

    }
}
