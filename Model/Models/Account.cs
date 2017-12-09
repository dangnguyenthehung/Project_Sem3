using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Account
    {
        public int IdAccount { get; set; }

        [DisplayName("Họ tên")]
        public string FullName { get; set; }
        
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; }

        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [DisplayName("Roles")]
        public List<int> Roles { get; set; }

        [DisplayName("Permission")]
        public List<int> Permissions { get; set; }
    }
}
