using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }

        [DisplayName("Identity Number")]
        [Required(ErrorMessage = "Identity Number must be provided")]
        [MaxLength(12)]
        [MinLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Identity Number must be numeric")]
        public string CMND { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Full name must be provided")]
        public string FullName { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Phone number must be provided")]
        [MinLength(10, ErrorMessage = "Number too short")]
        [MaxLength(12, ErrorMessage = "Number too long")]
        [Phone(ErrorMessage = "Not a valid format!")]
        public string Phone { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Sign up date")]
        public DateTime SignUpDate { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Roles")]
        public List<int> Roles { get; set; }

        [DisplayName("Permission")]
        public List<int> Permissions { get; set; }
    }
}
