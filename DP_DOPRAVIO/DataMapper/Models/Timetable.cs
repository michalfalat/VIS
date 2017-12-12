using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class Timetable
    {
        public Timetable()
        {
            this.driver = new Driver();
            this.vehicle = new Vehicle();
            this.route = new Route();
        }
        public int id_journey { get; set; }
        public string link_name { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public Route route { get; set; }
        public Vehicle vehicle { get; set; }
        public Driver driver { get; set; }
    }
}
