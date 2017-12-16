using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Web.Models;

namespace Web.SingleTon
{
    public class TableTypeSingleTon
    {
        private TableTypeSingleTon()
        {
            //
        }

        private static List<TableType> _listTypes = null;

        private TableTypeSingleTon _typeSingleTon = new TableTypeSingleTon();

        private static void GetData()
        {
            _listTypes = TableModel.GetListTableTypes();
        }

        public static List<TableType> GetListTypes()
        {
            if (_listTypes == null)
            {
                GetData();
            }

            return _listTypes;
        }

        public static TableType GetById(int id)
        {
            if (_listTypes == null)
            {
                GetData();
            }
            
            return _listTypes?.SingleOrDefault(r => r.Id_Table_Type == id);
        }

        public static string GetDescription(int id)
        {
            if (_listTypes == null)
            {
                GetData();
            }

            return _listTypes?.Where(r => r.Id_Table_Type == id).Select(r => r.Description).SingleOrDefault();
        }

        public static int GetCapacity(int id)
        {
            if (_listTypes == null)
            {
                GetData();
            }

            return _listTypes?.Where(r => r.Id_Table_Type == id).Select(r => r.TableCapacity).SingleOrDefault() ?? 0;
        }
    }
}
