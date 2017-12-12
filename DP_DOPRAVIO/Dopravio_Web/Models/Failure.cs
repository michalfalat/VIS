using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio_api.Models
{
    public class Failure
    {
        public Failure()
        {
            timetable = new Timetable();
        }


        public int id { get; set; }
        public DateTime created { get; set; }

        public FailureType type { get; set; }

        public string place { get; set; }
        public int severity { get; set; }
        public string message { get; set; }
        public Nullable<DateTime> resolved { get; set; }
        public Timetable timetable { get; set; }

    }
}
