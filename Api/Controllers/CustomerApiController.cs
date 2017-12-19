using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Helper;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerApiController : ApiController
    {
        private static readonly CustomerApiHelper Helper = new CustomerApiHelper();

        [Route("get_by_id/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var response = new HttpResponseMessage();

            var data = Helper.GetById(id);

            if (data != null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(JsonConvert.SerializeObject(data));
                return response;
            }
            
            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

    }
}
