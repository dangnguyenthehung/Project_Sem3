using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Helper;
using Model.DTO;
using Newtonsoft.Json;

namespace Api.Controllers
{
    public class SecurityApiController : ApiController
    {
        private static readonly SecurityApiHelper Helper = new SecurityApiHelper();

        [HttpGet]
        [Route("get_list_role_and_permission")]
        public HttpResponseMessage Get_List_Role_And_Permission()
        {
            var response = new HttpResponseMessage();
            
            List<RolesMapping> result = Helper.Get_ListRoles_And_Permission();

            if (result != null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(JsonConvert.SerializeObject(result));

                return response;
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }
    }
}
