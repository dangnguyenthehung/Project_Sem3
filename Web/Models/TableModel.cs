using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.Models;
using Web.Security;

namespace Web.Models
{
    public static class TableModel
    {
        private static readonly ApiUrls.Table ApiUrl = new ApiUrls.Table();
        private static readonly TableHelper Helper = new TableHelper();

        public static List<Table> GetByIdRestaurant(int id)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_By_Id_Restaurant;

            return Helper.GetByIdRestaurant(token, url, id);
        }

        public static Table GetTableById(int id)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_Table_By_Id;

            return Helper.GetTableById(token, url, id);
        }

        public static int InsertTable(Table model)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Insert_Table;

            return Helper.InsertTable(token, url, model);
        }

        public static bool UpdateTableById(Table model)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Update_Table_By_Id;

            return Helper.UpdateTableById(token, url, model);
        }
        
        public static bool DeleteTableById(int id, int idAccount)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Delete_Table_By_Id;

            return Helper.DeleteTableById(token, url, id, idAccount);
        }

        public static List<Table> GetTableAvailable(TableFilterDTO model)
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_Table_Available;

            return Helper.GetTableAvailable(token, url, model);
        }

        public static List<Table> GetListTable()
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_All;

            return Helper.GetAllTable(token, url);
        }

        //Table type
        public static List<TableType> GetListTableTypes()
        {
            var token = SessionPersister.ApiToken;
            var url = ApiUrl.Get_List_TableType;

            return Helper.GetListTableTypes(token, url);
        }
    }
}