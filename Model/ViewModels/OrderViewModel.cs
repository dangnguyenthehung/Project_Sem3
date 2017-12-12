using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Models;

namespace Model.ViewModels
{
    public class OrderViewModel
    {
        public Orders Order { get; set; }

        public List<Table> ListAvailableTables { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }
        
        public List<int> ListIdTable { get; set; }
    }
}
