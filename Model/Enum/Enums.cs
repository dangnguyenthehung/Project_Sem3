using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enum
{
    public static class Enums
    {
        public enum OrderStatus
        {
            New = 10,
            Verified = 20,
            Complete = 30,
            Cancel = 50,
            Refunded = 60
        }
    }
}
