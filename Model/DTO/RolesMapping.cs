using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class RolesMapping
    {
        public int IdRole { get; set; }

        public int IdPermission { get; set; }

        public RolesMapping(int role, int permissions)
        {
            IdRole = role;
            IdPermission = permissions;
        }
    }
}
