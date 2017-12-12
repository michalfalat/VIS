using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
   public  class Dispatcher: Employee
    {
        public Dispatcher()
        {

        }

        public int id { get; set; }
        public int skills { get; set; }

    }
}
