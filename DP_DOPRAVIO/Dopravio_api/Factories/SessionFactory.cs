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
    public class SessionFactory
    {
        public SessionGatewayInterface<Session> GetSessionInstance()
        {
            if (Configuration.SESSION_USE_SQL == true)
            {
                return SessionsTable<Session>.Instance;
            }
            else
            {
                return SessionXMLTable<Session>.Instance;
            }

        }
    }
}
