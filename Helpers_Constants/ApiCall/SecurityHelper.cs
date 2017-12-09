using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Newtonsoft.Json;

namespace Helpers_Constants.ApiCall
{
    public class SecurityHelper : BaseHelper
    {
        public List<RolesMapping> Get_ListRoles_And_Permission(string apiUrl)
        {
            return _Get<List<RolesMapping>>(apiUrl);
        }
    }
}
