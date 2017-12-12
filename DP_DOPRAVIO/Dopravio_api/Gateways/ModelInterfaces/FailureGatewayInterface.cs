using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio.Database
{
    public interface FailureGatewayInterface<T> : TableGateway<T> where T : Failure
    {
    }
}