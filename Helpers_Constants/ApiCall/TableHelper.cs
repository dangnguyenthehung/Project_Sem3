using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Models;

namespace Helpers_Constants.ApiCall
{
    public class TableHelper : BaseHelper
    {
        public List<Table> GetByIdRestaurant(string token, string apiUrl, int id)
        {
            return _Get_By_Id<List<Table>>(token, apiUrl, id);
        }

        public Table GetTableById(string token, string apiUrl, int id)
        {
            return _Get_By_Id<Table>(token, apiUrl, id);
        }

        public int InsertTable(string token, string apiUrl, Table model)
        {
            return _Insert(token, apiUrl, model);
        }

        public bool DeleteTableById(string token, string apiUrl, int id, int idAccount)
        {
            return _Delete(token, apiUrl, id, idAccount);
        }

        public bool UpdateTableById(string token, string apiUrl, Table model)
        {
            return _Update(token, apiUrl, model);
        }


        public List<Table> GetTableAvailable(string token, string apiUrl, TableFilterDTO model)
        {
            return _Get_By_Params_Object<List<Table>, TableFilterDTO>(token, apiUrl, model);
        }

        public List<Table> GetAllTable(string token, string apiUrl)
        {
            return _Get_All<Table>(token, apiUrl);
        }

        //table type
        public List<TableType> GetListTableTypes(string token, string apiUrl)
        {
            return _Get_All<TableType>(token, apiUrl);
        }

        public bool UpdateTableType(string token, string apiUrl, TableType model)
        {
            return _Update(token, apiUrl, model);
        }
    }
}
