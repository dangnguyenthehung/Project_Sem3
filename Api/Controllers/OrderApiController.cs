using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Helper;
using Model.DTO;
using Model.Functions;
using Model.Models;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderApiController : ApiController
    {
        private static readonly OrdersApiHelper Helper = new OrdersApiHelper();

        [Route("get_by_id/{id}")]
        [HttpGet]
        public HttpResponseMessage Get_By_Id(int id)
        {
            var response = new HttpResponseMessage();

            if (id > 0)
            {
                var result = Helper.GetById(id);

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

        [Route("get_list_order_table/{idOrder}")]
        [HttpGet]
        public HttpResponseMessage Get_List_Order_Table(int idOrder)
        {
            var response = new HttpResponseMessage();

            if (idOrder > 0)
            {
                var result = Helper.GetByIdOrder(idOrder);

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

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] OrderDTO orderData)
        {
            var response = new HttpResponseMessage();

            var result = Helper.Insert(orderData.Order);

            if (result > 0)
            {
                var temp = Insert_Order_Table(result, orderData.ListIdTable);

                if (temp)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));

                    return response;
                }
            }

            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }


        //Order Table
        
        private bool Insert_Order_Table(int idOrder, List<int> listTables)
        {
            List<OrderTableTableType> dataTable = new List<OrderTableTableType>();
            foreach (var item in listTables)
            {
                var row = new OrderTableTableType()
                {
                    IdOrder = idOrder,
                    IdTable = item
                };

                dataTable.Add(row);
            }

            DataTable table = HelperFunctions.ToDataTable(dataTable);
            var result = Helper.Insert_Order_Table(table);
            
            return result;
        }

    }
}
