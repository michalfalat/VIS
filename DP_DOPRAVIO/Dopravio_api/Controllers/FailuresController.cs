using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio.Database;
using Dopravio.Models;
using Dopravio_api.Factories;
using System.Collections.ObjectModel;

namespace Dopravio_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Failures")]
    public class FailuresController : Controller
    {
        // GET: api/Failures
        [HttpGet]
        public IEnumerable<Failure> Get()
        {
            FailureFactory failureFactory = new FailureFactory();
            FailureTable<Failure> ft = (FailureTable<Failure>)failureFactory.GetFailureInstance();
            Collection<Failure> failures = ft.Select();
            return failures;
        }

        // GET: api/Failures/5
        [HttpGet("{id}")]
        public Failure Get(int id)
        {
            FailureFactory failureFactory = new FailureFactory();
            FailureTable<Failure> ft = (FailureTable<Failure>)failureFactory.GetFailureInstance();
            Failure failure = ft.Select(id);
            return failure;
        }



        // GET: api/Failures/myJourneys
        [HttpGet("myFailures")]
        public IEnumerable<Failure> getDriversFailures()
        {
            SessionFactory sessionFactory = new SessionFactory();
            var instanceSession = sessionFactory.GetSessionInstance();

            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return new List<Failure>();
            }
            var driver = instanceSession.SelectDriverSession(token);
            if (driver == null)
            {
                return new List<Failure>();
            }

            FailureFactory failureFactory = new FailureFactory();
            FailureTable<Failure> instanceFailure = (FailureTable<Failure>)failureFactory.GetFailureInstance();
            var listFailures = instanceFailure.SelectDrivers(driver.id);

          
            return listFailures;
        }


        // POST: api/Failures
        [HttpPost]
        public string Post([FromBody]Failure obj)
        {
            SessionFactory sessionsFactory = new SessionFactory();
            SessionsTable<Session> instance = (SessionsTable<Session>)sessionsFactory.GetSessionInstance();
            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return "NOT LOGED";
            }
            var driver = instance.SelectDriverSession(token);
            if ( driver == null )
            {
                return "NOT EXISTING USER";
            }
            else if (obj == null)
            {
                return "NO OBJECT";
            }
            
            FailureFactory failureFactory = new FailureFactory();
            FailureTable<Failure> instanceFailure = (FailureTable<Failure>)failureFactory.GetFailureInstance();
            instanceFailure.Insert(obj);
            return "OK";
        }

        // PUT: api/Failures/5
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
