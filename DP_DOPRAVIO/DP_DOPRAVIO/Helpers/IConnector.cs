using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Helpers
{
    interface IConnector<T>
    {
        List<T> get();
        T get(int id);

        string delete(int id);

        string update(T obj);
    }
}
