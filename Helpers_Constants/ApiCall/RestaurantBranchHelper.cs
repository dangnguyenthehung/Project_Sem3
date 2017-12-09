using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Helpers_Constants.ApiCall
{
    public class RestaurantBranchHelper : BaseHelper
    {
        public List<RestaurantBranch> GetAll(string apiUrl)
        {
            return _Get_All<RestaurantBranch>(apiUrl);
        }
    }
}
