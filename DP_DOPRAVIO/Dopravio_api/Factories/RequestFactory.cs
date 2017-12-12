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
    public class RequestFactory
    {
        public RequestGatewayInterface<Request> GetRequestInstance()
        {
            if (Configuration.REQUEST_USE_SQL == true)
            {
                return RequestTable<Request>.Instance;
            }
            else
            {
                return RequestXMLTable<Request>.Instance;
            }

        }
    }
}
