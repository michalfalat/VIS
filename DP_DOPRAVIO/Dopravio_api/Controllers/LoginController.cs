using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio.Database;
using System.Threading;
using Dopravio_api.Factories;
using Dopravio.Models;
using Dopravio_api.Models;

namespace Dopravio_api.Controllers
{
    public class User
    {
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public string email { get; set; }
        public string password { get; set; }
    }

    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
       

        // POST: api/Login
        [HttpPost]
        public LoginResponse Post([FromBody]User u)
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();

            ManagerFactory managerFactory = new ManagerFactory();
            ManagerTable<Manager> instanceManager = (ManagerTable<Manager>)managerFactory.GetManagerInstance();

            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();

            SessionFactory sessionFactory = new SessionFactory();
            SessionsTable<Session> instanceSession = (SessionsTable<Session>)sessionFactory.GetSessionInstance();

            var dispatcher = instanceDispatcher.Login(u.email, u.password);
            var driver = instanceDriver.Login(u.email, u.password);
            var manager = instanceManager.Login(u.email, u.password);
            if (dispatcher != null)
            {
                var token = GenerateToken().ToString();
                Session s = new Session();
                s.token = token;
                s.type = "DISPATCHER";
                s.user_id = dispatcher.id;
                instanceSession.CreateSession(s);
                LoginResponse lr = new LoginResponse();
                lr.token = token;
                lr.type = "DISPATCHER";
                lr.email = dispatcher.email;
                return lr;
            }

            if (driver != null)
            {
                var token = GenerateToken().ToString();
                Session s = new Session();
                s.token = token;
                s.type = "DRIVER";
                s.user_id = driver.id;
                instanceSession.CreateSession(s);
                LoginResponse lr = new LoginResponse();
                lr.token = token;
                lr.type = "DRIVER";
                lr.email = driver.email;
                return lr;
            }

            if (manager != null)
            {
                var token = GenerateToken().ToString();
                Session s = new Session();
                s.token = token;
                s.type = "MANAGER";
                s.user_id = manager.id;
                instanceSession.CreateSession(s);
                LoginResponse lr = new LoginResponse();
                lr.token = token;
                lr.type = "MANAGER";
                lr.email = manager.email;
                return lr;
            }
            LoginResponse lr1 = new LoginResponse();
            lr1.token = null;
            lr1.type = "Užívatel neexistuje!";
            lr1.email = null;
            return lr1;
        }
      

        public Guid GenerateToken()
        {
            return Guid.NewGuid();
        }

      
    }

   
}
