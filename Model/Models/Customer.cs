using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string CMND { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime SignUpDate { get; set; }
        public string Password { get; set; }

        [DisplayName("Roles")]
        public List<int> Roles { get; set; }

        [DisplayName("Permission")]
        public List<int> Permissions { get; set; }
    }
}
