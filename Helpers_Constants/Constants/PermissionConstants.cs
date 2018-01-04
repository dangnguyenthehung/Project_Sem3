using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers_Constants.Constants
{
    public struct PermissionConstants
    {
        public struct Order
        {
            public const string Get_New = "11";
            public const string Get_Verified = "12";
            public const string Get_Completed = "13";
            public const string Get_Cancel = "14";
            public const string Get_Refunded = "15";
            public const string Insert = "16";
            public const string Update = "17";
            public const string Delete = "18";
        }
    }
}
