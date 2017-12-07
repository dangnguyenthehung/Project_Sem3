using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Models;

namespace Model.ViewModels
{
    public class BookingViewModel
    {
        public BookingInfoDTO BookingInfo { get; set; }

        public List<Table> ListTables { get; set; }
    }
}
