using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Helper;
using Api.Security;
using Model.DTO;
using Model.Models;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [RoutePrefix("api/table")]
    [CustomBasicAuthenticationFilter]
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

        [Route("get_table_by_id/{id}")]
        [HttpGet]
        public HttpResponseMessage Get_Table_By_Id(int id)
        {
            var response = new HttpResponseMessage();

            if (id > 0)
            {
                var result = Helper.Get_Table_By_Id(id);

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

        [Route("insert_table/")]
        [HttpPost]
        public HttpResponseMessage Insert_Table([FromBody] Table table)
        {
            var response = new HttpResponseMessage();

            if (table != null)
            {
                var result = Helper.Insert_Table(table);

                if (result != 0)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }
        [Route("delete_table_by_id/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete_Table_By_Id(int id)
        {
            var response = new HttpResponseMessage();

            if (id > 0)
            {
                var result = Helper.Delete_Table_By_Id(id);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }
        
        [Route("update_table_by_id/")]
        [HttpPut]
        public HttpResponseMessage Update_Table_By_Id([FromBody] Table table)
        {
            var response = new HttpResponseMessage();

            if (table != null)
            {
                var result = Helper.Update_Table_By_Id(table);

                if (result)
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
        [Route("get_list_table_all")]
        [HttpGet]
        public HttpResponseMessage Get_List_Table_All()
        {
            var response = new HttpResponseMessage();

            var result = Helper.Get_List_Table_All();

            if (result != null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(JsonConvert.SerializeObject(result));

                return response;
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

        [Route("update_tabletype/")]
        [HttpPut]
        public HttpResponseMessage Update_TableType([FromBody] TableType type)
        {
            var response = new HttpResponseMessage();

            if (type != null)
            {
                var result = Helper.Update_TableType(type);

                if (result)
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
