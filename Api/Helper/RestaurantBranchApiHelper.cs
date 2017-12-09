using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using Model.Functions;
using RestaurantBranch = Model.Models.RestaurantBranch;

namespace Api.Helper
{
    public class RestaurantBranchApiHelper
    {
        public List<RestaurantBranch> GetAll()
        {
            try
            {
                using (var context = new DatBanOnlineEntities())
                {
                    var response = context.Get_List_RestaurantBranch_All().ToList();

                    if (response.Any())
                    {
                        var result = response.Select(r => r.Cast<RestaurantBranch>()).ToList();
                        return result;
                    }
                    
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}