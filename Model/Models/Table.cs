using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Table
    {
        public int IdTable { get; set; }

        [DisplayName("Restaurant Branch")]
        public int RestaurantId { get; set; }

        [DisplayName("Table Number")]
        public int TableNumber { get; set; }

        [DisplayName("Table Type")]
        public int IdTableType { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
