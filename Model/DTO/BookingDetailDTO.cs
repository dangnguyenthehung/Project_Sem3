using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class BookingDetailDTO
    {
        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public int NumberOfCustomers { get; set; }

        public List<NumberOfTableDTO> ListNumberOfTable { get; set; }
    }
}
