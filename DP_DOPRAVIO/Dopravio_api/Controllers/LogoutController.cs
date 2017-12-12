using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio.Database;
using Dopravio_api.Factories;

namespace Dopravio_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Logout")]
    public class LogoutController : Controller
    {
        // POST: api/Logout
        [HttpPost]
        public string Post()
        {
            SessionFactory sessionFactory = new SessionFactory();
            SessionsTable<Session> instanceSession = (SessionsTable<Session>)sessionFactory.GetSessionInstance();
            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            instanceSession.Delete(token);
            return "LOGOUT_SUCCESS";
        }
        
        
    }
}
