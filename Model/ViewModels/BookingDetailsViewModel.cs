using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Model.ViewModels
{
    public class BookingDetailsViewModel
    {
        public Customer Customer { get; set; }

        public Orders Order { get; set; }
        
        public List<int> ListIdTable { get; set; }
    }
}
