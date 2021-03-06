﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Models;

namespace Model.ViewModels
{
    public class OrderViewModel
    {
        public Orders Order { get; set; }

        public List<Table> ListAvailableTables { get; set; }

        public DateTime OrderDate { get; set; }

        public string BeginTime { get; set; }

        public string EndTime { get; set; }
        
        public List<int> ListIdTable { get; set; }

        public string DepositToken { get; set; }
    }
}
