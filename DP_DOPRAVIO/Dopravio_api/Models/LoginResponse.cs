using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio_api.Models
{
    public class LoginResponse
    {
        public LoginResponse()
        {

        }
        public string token { get; set; }
        public string type { get; set; }
        public string email { get; set; }

    }
}
