using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string StaffId { get; set; }
        public string FullName { get; set; }
        public int IdBranch { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime EnterDate { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }

        [DisplayName("Roles")]
        public List<int> Roles { get; set; }

        [DisplayName("Permission")]
        public List<int> Permissions { get; set; }
    }
}
