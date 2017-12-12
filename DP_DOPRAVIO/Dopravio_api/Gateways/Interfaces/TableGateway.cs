using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Database
{
    public interface TableGateway<T>
        where T : class
    {
        int Insert(T obj);
        int Update(T obj);
        Collection<T> Select();
        T Select(int id);
        int Delete(int id);
    }
}