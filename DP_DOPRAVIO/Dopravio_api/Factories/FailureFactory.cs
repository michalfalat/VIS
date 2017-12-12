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
    public class FailureFactory
    {
        public   FailureGatewayInterface<Failure> GetFailureInstance()
        {
            if (Configuration.FAILURE_USE_SQL == true)
            {
                return FailureTable<Failure>.Instance;
            }
            else
            {
                return FailureXMLTable<Failure>.Instance;
            }

        }
    }
}
