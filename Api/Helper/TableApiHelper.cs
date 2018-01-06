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

        public Table Get_Table_By_Id(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Get_Table_By_Id(id).SingleOrDefault();

                        var result = response.Cast<Table>();

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

        public bool Delete_Table_By_Id(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Delete_Table_By_Id(id);
                        
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int Insert_Table(Table table)
        {
            try
            {
                if (table != null)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Insert_Table(table.IdTable, table.IdTableType, table.TableNumber, table.Description).SingleOrDefault();

                        if (response != null && response.IdTable != 0)
                        {
                            return response.IdTable;
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Update_Table_By_Id(Table table)
        {
            try
            {
                if (table != null)
                {
                    using (var context = new DatBanOnlineEntities())
                    {
                        var response = context.Update_Table_By_Id(table.IdTable, table.IdTableType, table.TableNumber, table.Description);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
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

        public List<Table> Get_List_Table_All()
        {
            try
            {
                using (var context = new DatBanOnlineEntities())
                {
                    var response = context.Get_All_Table().ToList();

                    var result = response.Select(t => t.Cast<Table>()).ToList();

                    return result;
                }
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

        public bool Update_TableType(TableType type)
        {
            try
            {
                using (var context = new DatBanOnlineEntities())
                {
                    var response = context.Update_TableType_By_Id(type.Id_Table_Type, type.TableCapacity, type.Description, type.DepositFee);
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}