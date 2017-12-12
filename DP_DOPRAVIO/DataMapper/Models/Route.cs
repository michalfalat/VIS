using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class Route
    {
        public int id_route { get; set; }
        public string start { get; set; }
        public string finish { get; set; }
        public int stops_count { get; set; }
        public double distance { get; set; }
    }
}
