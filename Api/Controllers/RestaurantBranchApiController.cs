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
    [RoutePrefix("api/branch")]
    public class RestaurantBranchApiController : ApiController
    {
        private static readonly RestaurantBranchApiHelper Helper = new RestaurantBranchApiHelper();

        [Route("getall")]
        public HttpResponseMessage GetAll()
        {
            var response = new HttpResponseMessage();

            var data = Helper.GetAll();

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
