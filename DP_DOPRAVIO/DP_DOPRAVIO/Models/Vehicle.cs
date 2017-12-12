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
        public decimal consumption { get; set; }

        public string detail { get { return $"{name} ({capacity} ľudí)"; } }
    }
}
