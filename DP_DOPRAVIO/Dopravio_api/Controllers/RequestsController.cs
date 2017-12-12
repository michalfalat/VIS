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
    [Route("api/Requests")]
    public class RequestsController : Controller
    {
        // GET: api/Requests
        [HttpGet]
        public IEnumerable<Request> Get()
        {
            RequestFactory requestFactory = new RequestFactory();
            RequestTable<Request> instance = (RequestTable<Request>)requestFactory.GetRequestInstance();
            return instance.Select();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public Request Get(int id)
        {
            RequestFactory requestFactory = new RequestFactory();
            RequestTable<Request> instance = (RequestTable<Request>)requestFactory.GetRequestInstance();
            return instance.Select(id);
        }
        
        // POST: api/Requests
        [HttpPost]
        public string Post([FromBody]Request obj)
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
            obj.resultMessage = "";
            obj.dispatcher = new Dopravio.Models.Dispatcher();
            obj.dispatcher.id = dispatcher.id;

            RequestFactory requestFactory = new RequestFactory();
            RequestTable<Request> instanceRequest = (RequestTable<Request>)requestFactory.GetRequestInstance();
            instanceRequest.Insert(obj);
            return "OK";
        }
        
        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Request obj)
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
            RequestFactory requestFactory = new RequestFactory();
            RequestTable<Request> instanceRequest = (RequestTable<Request>)requestFactory.GetRequestInstance();
            instanceRequest.Update(obj);
            return "OK";
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
