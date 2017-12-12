using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class Route
    {
        public int id { get; set; }
        public string start { get; set; }
        public string finish { get; set; }
        public decimal distance { get; set; }
    }
}
