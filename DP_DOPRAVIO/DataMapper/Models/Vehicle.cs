using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
        }
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public int capacity { get; set; }
        public double consumption { get; set; }
        public decimal cost_price { get; set; }
    }
}
