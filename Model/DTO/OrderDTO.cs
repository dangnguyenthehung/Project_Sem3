﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Model.DTO
{
    public class OrderDTO
    {
        public Orders Order { get; set; }

        public List<int> ListIdTable { get; set; }

    }
}