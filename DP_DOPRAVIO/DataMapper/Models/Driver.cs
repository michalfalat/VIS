﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    class Driver : Employee
    {
        public Driver()
        {
        }
        public int id { get; set; }
        public int accidentCount { get; set; }
    }
}
