using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio_api.Models;
using Dopravio_api.Factories;
using Dopravio.Database;
using Dopravio.Models;

namespace Dopravio_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Overview")]
    public class OverviewController : Controller
    {
        // GET: api/Overview
        [HttpGet]
        public Overview Get()
        {
            SessionFactory sessionsFactory = new SessionFactory();
            SessionsTable<Session> instance = (SessionsTable<Session>)sessionsFactory.GetSessionInstance();
            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return new Overview();
            }
            var dispatcher = instance.SelectDispatcherSession(token);
            var driver = instance.SelectDriverSession(token);
            var manager = instance.SelectManagerSession(token);
            if (dispatcher == null && driver == null && manager == null)
            {
                return new Overview();
            }
           
            Overview obj = new Overview();

            RequestFactory requestFactory = new RequestFactory();
            RequestTable<Request> instanceRequest = (RequestTable<Request>)requestFactory.GetRequestInstance();
           var requests =  instanceRequest.Select();
            obj.acceptedRequests = requests.Where(r => r.state == RequestState.ACCEPTED).Count();
            obj.declinedRequests = requests.Where(r => r.state == RequestState.DECLINED).Count();
            obj.newRequests = requests.Where(r => r.state == RequestState.NEW).Count();


            decimal salary = 0;
            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();
            var listDrivers = instanceDriver.Select();
            obj.driverCount = listDrivers.Count();
            salary += listDrivers.Sum(dr => dr.salary);

            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();
            var listDispatchers = instanceDispatcher.Select();
            obj.dispatcherCount = listDispatchers.Count();
            salary += listDispatchers.Sum(dis => dis.salary);

            obj.monthSalary = salary;


            VehicleFactory vehicleFactory = new VehicleFactory();
            var instanceVehicle = vehicleFactory.GetVehicleInstance();
            obj.vehicleCount = instanceVehicle.Select().Count();

            FailureFactory failureFactory = new FailureFactory();
            FailureTable<Failure> instanceFailure = (FailureTable<Failure>)failureFactory.GetFailureInstance();
            var listFailures = instanceFailure.Select();
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            obj.failurestInLastMonth = listFailures.Where(d => d.created > lastMonth).Count();
            obj.failures = listFailures.Count();
            return obj;
        }


    }
}
