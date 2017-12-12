using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Web.Models;

namespace Web.SingleTon
{
    public class BranchSingleTon
    {
        private BranchSingleTon()
        {
            //
        }

        private static List<RestaurantBranch> _listBranchs = null;

        private BranchSingleTon _branchSingleTon = new BranchSingleTon();

        private static void GetData()
        {
            _listBranchs = RestaurantBranchModel.GetAll();
        }

        public static List<RestaurantBranch> GetListBranches()
        {
            if (_listBranchs == null)
            {
                GetData();
            }

            return _listBranchs;
        }

        public static RestaurantBranch GetById(int id)
        {
            if (_listBranchs == null)
            {
                GetData();
            }
            
            return _listBranchs?.SingleOrDefault(r => r.IdBranch == id);
        }

        public static string GetAddress(int id)
        {
            if (_listBranchs == null)
            {
                GetData();
            }

            return _listBranchs?.Where(r => r.IdBranch == id).Select(r => r.Address).SingleOrDefault();
        }
    }
}
