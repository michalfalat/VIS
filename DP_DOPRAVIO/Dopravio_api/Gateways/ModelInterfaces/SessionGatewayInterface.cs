using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio.Database
{
    public interface SessionGatewayInterface<T> : TableGateway<T> where T : Session
    {

        Dispatcher SelectDispatcherSession(string token);
        Driver SelectDriverSession(string token);
        Manager SelectManagerSession(string token);
    }
}