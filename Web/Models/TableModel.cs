﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.ApiCall;
using Helpers_Constants.Constants;
using Model.DTO;
using Model.Models;

namespace Web.Models
{
    public static class TableModel
    {
        private static readonly ApiUrls.Table ApiUrl = new ApiUrls.Table();
        private static readonly TableHelper Helper = new TableHelper();

        public static List<Table> GetByIdRestaurant(int id)
        {
            var url = ApiUrl.Get_By_Id_Restaurant;

            return Helper.GetByIdRestaurant(url, id);
        }

        public static Table GetTableById(int id)
        {
            var url = ApiUrl.Get_Table_By_Id;

            return Helper.GetTableById(url, id);
        }

        public static int InsertTable(Table model)
        {
            var url = ApiUrl.Insert_Table;

            return Helper.InsertTable(url, model);
        }

        public static bool UpdateTableById(Table model)
        {
            var url = ApiUrl.Update_Table_By_Id;

            return Helper.UpdateTableById(url, model);
        }
        
        public static bool DeleteTableById(int id, int idAccount)
        {
            var url = ApiUrl.Delete_Table_By_Id;

            return Helper.DeleteTableById(url, id, idAccount);
        }

        public static List<Table> GetTableAvailable(TableFilterDTO model)
        {
            var url = ApiUrl.Get_Table_Available;

            return Helper.GetTableAvailable(url, model);
        }

        public static List<Table> GetListTable()
        {
            var url = ApiUrl.Get_All;

            return Helper.GetAllTable(url);
        }

        //Table type
        public static List<TableType> GetListTableTypes()
        {
            var url = ApiUrl.Get_List_TableType;

            return Helper.GetListTableTypes(url);
        }
    }
}