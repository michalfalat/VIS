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
    public class DispatcherFactory
    {
        public DispatcherGatewayInterface<Dispatcher> GetDispatcherInstance()
        {
            if (Configuration.DISPATCHER_USE_SQL == true)
            {
                return DispatcherTable<Dispatcher>.Instance;
            }
            else
            {
                return DispatcherXMLTable<Dispatcher>.Instance;
            }

        }
    }
}
