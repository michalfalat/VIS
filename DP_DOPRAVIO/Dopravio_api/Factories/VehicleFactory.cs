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
    public class VehicleFactory
    {
        public VehicleGatewayInterface<Vehicle> GetVehicleInstance()
        {
            if (Configuration.VEHICLE_USE_SQL == true)
            {
                return VehicleTable<Vehicle>.Instance;
            }
            else
            {
                return VehicleXMLTable<Vehicle>.Instance;
            }

        }
    }
}
