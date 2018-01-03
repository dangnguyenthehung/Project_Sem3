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
        public List<Table> GetByIdRestaurant(string apiUrl, int id)
        {
            return _Get_By_Id<List<Table>>(apiUrl, id);
        }

        public Table GetTableById(string apiUrl, int id)
        {
            return _Get_By_Id<Table>(apiUrl, id);
        }

        public int InsertTable(string apiUrl, Table model)
        {
            return _Insert(apiUrl, model);
        }

        public bool DeleteTableById(string apiUrl, int id, int idAccount)
        {
            return _Delete(apiUrl, id, idAccount);
        }

        public bool UpdateTableById(string apiUrl, Table model)
        {
            return _Update(apiUrl, model);
        }


        public List<Table> GetTableAvailable(string apiUrl, TableFilterDTO model)
        {
            return _Get_By_Params_Object<List<Table>, TableFilterDTO>(apiUrl, model);
        }

        public List<Table> GetAllTable(string apiUrl)
        {
            return _Get_All<Table>(apiUrl);
        }

        //table type
        public List<TableType> GetListTableTypes(string apiUrl)
        {
            return _Get_All<TableType>(apiUrl);
        }
    }
}
