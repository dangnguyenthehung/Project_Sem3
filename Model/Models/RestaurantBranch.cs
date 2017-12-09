using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class RestaurantBranch
    {
        public int IdBranch { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }
}
