using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio.Models;
using Dopravio.Database;
using Dopravio_api.Factories;

namespace Dopravio_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Drivers")]
    public class DriversController : Controller
    {
        // GET: api/Drivers
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();
            return instanceDriver.Select();
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();
            return instanceDriver.Select(id);
        }
        
        // POST: api/Drivers
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Drivers/5
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
