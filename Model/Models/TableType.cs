using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class TableType
    {
        public int Id_Table_Type { get; set; }

        [DisplayName("Sức chứa")]
        public int TableCapacity { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }
}
