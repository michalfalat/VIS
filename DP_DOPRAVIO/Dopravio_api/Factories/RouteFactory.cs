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
    public class RouteFactory
    {
        public RouteGatewayInterface<Route> GetRouteInstance()
        {
            if (Configuration.ROUTE_USE_SQL == true)
            {
                return RouteTable<Route>.Instance;
            }
            else
            {
                return RouteXMLTable<Route>.Instance;
            }

        }
    }
}
