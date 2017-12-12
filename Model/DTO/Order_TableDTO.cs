using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class Order_TableDTO
    {
        public int IdOrder { get; set; }

        public List<int> ListTableNumber { get; set; }
    }
}
