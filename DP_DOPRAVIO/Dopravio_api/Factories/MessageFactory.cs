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
    public class MessageFactory
    {
        public MessageGatewayInterface<Message> GetMessageInstance()
        {
            if (Configuration.MESSAGE_USE_SQL == true)
            {
                return MessageTable<Message>.Instance;
            }
            else
            {
                return MessageXMLTable<Message>.Instance;
            }

        }
    }
}
