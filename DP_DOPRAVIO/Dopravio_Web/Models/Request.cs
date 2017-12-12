using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio_api.Models
{
    public class Request
    {

        public Request()
        {
            dispatcher = new Dispatcher();
        }

        public int id { get; set; }
        public RequestState state { get; set; }
        public RequestType type { get; set; }
        public int priority { get; set; }
        public DateTime created { get; set; }
        public string message { get; set; }
        public string resultMessage { get; set; }
        public Dispatcher dispatcher { get; set; }
    }
}
