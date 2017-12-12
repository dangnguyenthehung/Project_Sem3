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
    [RoutePrefix("api/table")]
    public class TableApiController : ApiController
    {
        private static readonly TableApiHelper Helper = new TableApiHelper();

        [Route("get_by_id_restaurant/{id}")]
        [HttpGet]
        public HttpResponseMessage Get_By_Id_Restaurant(int id)
        {
            var response = new HttpResponseMessage();

            if (id > 0)
            {
                var result = Helper.Get_By_Id_Restaurant(id);

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

        [Route("get_table_available/")]
        [HttpPost]
        public HttpResponseMessage Get_Table_Available([FromBody] TableFilterDTO model)
        {
            var response = new HttpResponseMessage();

            if (model != null)
            {
                var result = Helper.Get_Table_Available(model);

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


        //Table type

        [Route("get_list_tabletype")]
        [HttpGet]
        public HttpResponseMessage Get_List_TableType()
        {
            var response = new HttpResponseMessage();

            var result = Helper.Get_List_TableType();

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
