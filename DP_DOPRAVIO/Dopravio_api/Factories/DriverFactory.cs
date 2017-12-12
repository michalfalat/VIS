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
    public class DriverFactory
    {
        public DriverGatewayInterface<Driver> GetDriverInstance()
        {
            if (Configuration.DRIVER_USE_SQL == true)
            {
                return DriverTable<Driver>.Instance;
            }
            else
            {
                return DriverXMLTable<Driver>.Instance;
            }

        }
    }
}
