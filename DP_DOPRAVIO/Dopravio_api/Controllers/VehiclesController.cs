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
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public VehiclesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/Vehicles
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            SessionFactory sessionFactory = new SessionFactory();
            var instanceSession = sessionFactory.GetSessionInstance();

            VehicleFactory vehicleFactory = new VehicleFactory();
            var instanceVehicle = vehicleFactory.GetVehicleInstance();

            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if(token == null)
            {
                return new List<Vehicle>();
            }
            var dispatcher = instanceSession.SelectDispatcherSession(token);
            var driver = instanceSession.SelectDriverSession(token);
            var manager = instanceSession.SelectManagerSession(token);
            if (dispatcher == null && driver == null && manager == null)
            {
                return new List<Vehicle>();
            }
            else
            {
                return instanceVehicle.Select();
            }
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public Vehicle Get(int id)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            var instanceVehicle = vehicleFactory.GetVehicleInstance();
            return instanceVehicle.Select(id);
        }
        
        // POST: api/Vehicles
        [HttpPost]
        public string Post([FromBody]Vehicle obj)
        {

            SessionFactory sessionsFactory = new SessionFactory();
            SessionsTable<Session> instance = (SessionsTable<Session>)sessionsFactory.GetSessionInstance();
            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return "NOT LOGED";
            }
            var dispatcher = instance.SelectDispatcherSession(token);
            var driver = instance.SelectDriverSession(token);
            var manager = instance.SelectManagerSession(token);
            if (dispatcher == null && driver == null && manager == null)
            {
                return "NOT EXISTING USER";
            }
            else if (obj == null)
            {
                return "NO OBJECT";
            }
            

            VehicleFactory vehicleFactory = new VehicleFactory();
            var instanceVehicle = vehicleFactory.GetVehicleInstance();
            instanceVehicle.Insert(obj);
            return "OK";
        }

        // PUT: api/Vehicles/5
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
