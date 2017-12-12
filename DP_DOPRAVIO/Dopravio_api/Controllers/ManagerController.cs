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
    [Route("api/Manager")]
    public class ManagerController : Controller
    {
        // GET: api/Manager
        [HttpGet]
        public IEnumerable<Manager> Get()
        {
            ManagerFactory managerFactory = new ManagerFactory();
            ManagerTable<Manager> instanceManager = (ManagerTable<Manager>)managerFactory.GetManagerInstance();
            return instanceManager.Select();
        }

        // GET: api/Manager/5
        [HttpGet("{id}")]
        public Manager Get(int id)
        {

            ManagerFactory managerFactory = new ManagerFactory();
            ManagerTable<Manager> instanceManager = (ManagerTable<Manager>)managerFactory.GetManagerInstance();
            return instanceManager.Select(id);
        }
        
        // POST: api/Manager
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Manager/5
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
