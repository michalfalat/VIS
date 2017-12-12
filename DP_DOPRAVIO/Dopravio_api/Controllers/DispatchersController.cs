using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio.Database;
using Dopravio.Models;
using Dopravio_api.Factories;

namespace Dopravio_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Dispatchers")]
    public class DispatchersController : Controller
    {
        // GET: api/Dispatchers
        [HttpGet]
        public IEnumerable<Dispatcher> Get()
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();
            return instanceDispatcher.Select();
        }

        // GET: api/Dispatchers/5
        [HttpGet("{id}")]
        public Dispatcher Get(int id)
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();
            return instanceDispatcher.Select(id);
        }
        
        // POST: api/Dispatchers
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Dispatchers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
