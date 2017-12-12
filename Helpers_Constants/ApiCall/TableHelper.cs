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

        public List<Table> GetTableAvailable(string apiUrl, TableFilterDTO model)
        {
            return _Get_By_Params_Object<Table, TableFilterDTO>(apiUrl, model);
        }

        //table type
        public List<TableType> GetListTableTypes(string apiUrl)
        {
            return _Get_All<TableType>(apiUrl);
        }
    }
}
