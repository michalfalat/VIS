using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio_api.Config
{
    public class Configuration
    {

        public static string XMLFILEPATH = Path.Combine(Environment.CurrentDirectory, @"data_dopravio.xml");
        public static bool DISPATCHER_USE_SQL = true;
        public static bool DRIVER_USE_SQL = true;
        public static bool FAILURE_USE_SQL = true;
        public static bool MANAGER_USE_SQL = true;
        public static bool MESSAGE_USE_SQL = true;
        public static bool REQUEST_USE_SQL = true;
        public static bool ROUTE_USE_SQL = true;
        public static bool SESSION_USE_SQL = true;
        public static bool TIMETABLE_USE_SQL = true;
        public static bool VEHICLE_USE_SQL = true;
    }
}
