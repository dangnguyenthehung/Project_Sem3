using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Table
    {
        public int IdTable { get; set; }

        public int RestaurantId { get; set; }

        public int TableNumber { get; set; }

        public int IdTableType { get; set; }

        public string Description { get; set; }
    }
}
