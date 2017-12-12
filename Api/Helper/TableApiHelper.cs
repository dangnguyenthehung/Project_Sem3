using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using Model.DTO;
using Model.Functions;
using Model.Models;

namespace Api.Helper
{
    public class TableApiHelper
    {
        public List<Table> Get_By_Id_Restaurant(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Get_List_Table_By_Restaurant_Id(id).ToList();

                        var result = response.Select(t => t.Cast<Table>()).ToList();

                        return result;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Table> Get_Table_Available(TableFilterDTO model)
        {
            try
            {
                if (model != null)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Get_List_Table_Available(model.IdBranch, model.BeginTime, model.EndTime).ToList();

                        var result = response.Select(t => t.Cast<Table>()).ToList();

                        return result;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Table Type

        public List<TableType> Get_List_TableType()
        {
            try
            {
                using (var context = new DatBanOnlineEntities())
                {
                    var response = context.Get_List_TableType().ToList();

                    var result = response.Select(t => t.Cast<TableType>()).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}