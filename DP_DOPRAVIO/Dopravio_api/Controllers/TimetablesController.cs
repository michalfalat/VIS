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
    [Route("api/Timetables")]
    public class TimetablesController : Controller
    {
        // GET: api/Timetables
        [HttpGet]
        public IEnumerable<TimetableDTO> Get()
        {

            TimetableFactory timetableFactory = new TimetableFactory();
            TimetableTable<Timetable> instanceTimetable = (TimetableTable<Timetable>)timetableFactory.GetTimetableInstance();
            var listDTO = new List<TimetableDTO>();
            var list = instanceTimetable.Select();
            foreach(var item in list)
            {
                listDTO.Add( new TimetableDTO( item));
            }
            return listDTO;
        }


        // GET: api/Timetables/myJourneys
        [HttpGet("myJourneys")]
        public IEnumerable<TimetableDTO> GetDriversJourneys()
        {
            SessionFactory sessionFactory = new SessionFactory();
            var instanceSession = sessionFactory.GetSessionInstance();

            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return new List<TimetableDTO>();
            }
            var driver = instanceSession.SelectDriverSession(token);
            if (driver == null)
            {
                return new List<TimetableDTO>();
            }

            TimetableFactory timetableFactory = new TimetableFactory();
            TimetableTable<Timetable> instanceTimetable = (TimetableTable<Timetable>)timetableFactory.GetTimetableInstance();
            var listTimetables = instanceTimetable.SelectDrivers(driver.id);

            var listDTO = new List<TimetableDTO>();
            foreach (var item in listTimetables)
            {
                listDTO.Add(new TimetableDTO(item));
            }
            return listDTO;
        }

        // GET: api/Timetables/5
        [HttpGet("{id}")]
        public TimetableDTO Get(int id)
        {
            TimetableFactory timetableFactory = new TimetableFactory();
            TimetableTable<Timetable> instanceTimetable = (TimetableTable<Timetable>)timetableFactory.GetTimetableInstance();
            return new TimetableDTO(instanceTimetable.Select(id));
        }
        
        // POST: api/Timetables
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Timetables/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Timetable timetable)
        {
            SessionFactory sessionFactory = new SessionFactory();
            SessionsTable<Session> instanceSession = (SessionsTable<Session>)sessionFactory.GetSessionInstance();

            TimetableFactory timetableFactory = new TimetableFactory();
            TimetableTable<Timetable> instanceTimetable = (TimetableTable<Timetable>)timetableFactory.GetTimetableInstance();
            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return "NOT LOGED";
            }
            var dispatcher = instanceSession.SelectDispatcherSession(token);
            var driver = instanceSession.SelectDriverSession(token);
            var manager = instanceSession.SelectManagerSession(token);
            if (dispatcher == null && driver == null && manager == null)
            {
                return "NOT EXISTING USER";
            }
            else if (timetable == null)
            {
                return "NO OBJECT";
            }

            instanceTimetable.Update(timetable);
            return "OK";
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
