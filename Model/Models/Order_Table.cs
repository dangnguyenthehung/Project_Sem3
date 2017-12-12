using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Order_Table
    {
        public int Id_Order_Table { get; set; }
        public int IdOrder { get; set; }
        public int IdTable { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
    }
}
