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
    public class ManagerFactory
    {
        public ManagerGatewayInterface<Manager> GetManagerInstance()
        {
            if (Configuration.MANAGER_USE_SQL == true)
            {
                return ManagerTable<Manager>.Instance;
            }
            else
            {
                return ManagerXMLTable<Manager>.Instance;
            }

        }
    }
}
