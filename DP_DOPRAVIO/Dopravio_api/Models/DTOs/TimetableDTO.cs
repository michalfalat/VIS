using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class TimetableDTO
    {
        public TimetableDTO(Timetable td)
        {
            this.id = td.id;
            this.name = td.name;
            this.departure = td.departure;
            this.arrival = td.arrival;

            this.driver = new DriverDTO(td.driver);
            this.vehicle = td.vehicle;
            this.route = td.route;

        }
        public int id { get; set; }
        public string name{ get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public Route route { get; set; }
        public Vehicle vehicle { get; set; }
        public DriverDTO driver { get; set; }
    }
}
