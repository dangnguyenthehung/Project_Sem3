using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class BookingInfoDTO
    {
        public string FullName { get; set; }

        public string CMND { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int IdBranch { get; set; }
    }
}
