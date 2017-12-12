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
    [Route("api/Routes")]
    public class RoutesController : Controller
    {
        // GET: api/Routes
        [HttpGet]
        public IEnumerable<Route> Get()
        {
            RouteFactory routeFactory = new RouteFactory();
            RouteTable<Route> instanceRoute = (RouteTable<Route>)routeFactory.GetRouteInstance();
            return instanceRoute.Select();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public Route Get(int id)
        {
            RouteFactory routeFactory = new RouteFactory();
            RouteTable<Route> instanceRoute = (RouteTable<Route>)routeFactory.GetRouteInstance();
            return instanceRoute.Select(id);
        }
        
        // POST: api/Routes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Routes/5
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
