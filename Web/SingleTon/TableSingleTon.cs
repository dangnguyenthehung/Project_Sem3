using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Web.Models;

namespace Web.SingleTon
{
    public class TableSingleTon
    {
        private TableSingleTon()
        {
            //
        }

        private static List<Table> _listTables = null;

        private TableSingleTon _tableSingleTon = new TableSingleTon();

        private static void GetData()
        {
            _listTables = TableModel.GetListTable();
        }

        public static void UpdateData()
        {
            GetData();
        }

        public static List<Table> GetListTables()
        {
            if (_listTables == null)
            {
                GetData();
            }

            return _listTables;
        }

        public static Table GetById(int id)
        {
            if (_listTables == null)
            {
                GetData();
            }
            
            return _listTables?.SingleOrDefault(r => r.IdTable == id);
        }

        public static string GetDescription(int id)
        {
            if (_listTables == null)
            {
                GetData();
            }

            return _listTables?.Where(r => r.IdTable == id).Select(r => r.Description).SingleOrDefault();
        }

        public static int GetTableNumber(int id)
        {
            if (_listTables == null)
            {
                GetData();
            }

            return _listTables?.Where(r => r.IdTable== id).Select(r => r.TableNumber).SingleOrDefault() ?? 0;
        }

        public static decimal GetTableDepositFee(int id)
        {
            if (_listTables == null)
            {
                GetData();
            }
            var table = GetById(id);
            return TableTypeSingleTon.GetDepositFee(table.IdTableType);
        }

        public static decimal GetTableCapacity(int id)
        {
            if (_listTables == null)
            {
                GetData();
            }
            var table = GetById(id);
            return TableTypeSingleTon.GetCapacity(table.IdTableType);
        }
    }
}
