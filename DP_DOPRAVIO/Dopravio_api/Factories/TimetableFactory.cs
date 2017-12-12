using Dopravio.Database;
using Dopravio.Models;
using Dopravio_api.Config;
using Dopravio_api.Gateways.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio_api.Factories
{
    public class TimetableFactory
    {
        public TimetableGatewayInterface<Timetable> GetTimetableInstance()
        {
            if (Configuration.TIMETABLE_USE_SQL == true)
            {
                return TimetableTable<Timetable>.Instance;
            }
            else
            {
                return TimetableXMLTable<Timetable>.Instance;
            }

        }
    }
}
