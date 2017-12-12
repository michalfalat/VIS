using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class Message
    {

        public Message()
        {
            dispatcher = new Dispatcher();
            manager = new Manager();
        }

        public int id { get; set; }
        public DateTime created { get; set; }
        public string text { get; set; }
        public bool? isRead { get; set; }
        public Dispatcher  dispatcher { get; set; }
        public Manager manager { get; set; }
    }
}
