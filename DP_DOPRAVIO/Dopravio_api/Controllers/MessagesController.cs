using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dopravio.Database;
using Dopravio_api.Factories;
using Dopravio.Models;
using System.Collections.ObjectModel;

namespace Dopravio_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        // GET: api/Messages
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            MessageFactory messageFactory = new MessageFactory();
            MessageTable<Message> instance = (MessageTable<Message>)messageFactory.GetMessageInstance();
            Collection<Message> messages = instance.Select();
            return messages;
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public Message Get(int id)
        {
            MessageFactory messageFactory = new MessageFactory();
            MessageTable<Message> instance = (MessageTable<Message>)messageFactory.GetMessageInstance();
           Message message = instance.Select(id);
            return message;
        }

        // GET: api/Messages/manager
        [HttpGet("manager")]
        public IEnumerable<Message> GetManagers()
        {
            SessionFactory sessionsFactory = new SessionFactory();
            SessionsTable<Session> instance = (SessionsTable<Session>)sessionsFactory.GetSessionInstance();
            var list = Request.Headers.ToList();
            var token = list.Where(a => a.Key == "token")?.FirstOrDefault().Value.FirstOrDefault()?.Replace("\"", string.Empty);
            if (token == null)
            {
                return new List<Message>();
            }
            var manager = instance.SelectManagerSession(token);
            if ( manager == null)
            {
                return new List<Message>();
            }
            MessageFactory messageFactory = new MessageFactory();
            MessageTable<Message> instanceMessage = (MessageTable<Message>)messageFactory.GetMessageInstance();
            var messages = instanceMessage.SelectForManager(manager.id);
            var copy = instanceMessage.SelectForManager(manager.id);
            foreach (var item in copy)
            {
                item.isRead = true;
                instanceMessage.Update(item);
            }
            return messages;
        }

        // POST: api/Messages
        [HttpPost]
        public string Post([FromBody]Message obj)
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

            obj.dispatcher = new Dopravio.Models.Dispatcher();
            obj.dispatcher.id = dispatcher.id;

            MessageFactory messageFactory = new MessageFactory();
            MessageTable<Message> instanceMessage = (MessageTable<Message>)messageFactory.GetMessageInstance();
            instanceMessage.Insert(obj);
            return "OK";
        }
        
       
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
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
            

            MessageFactory messageFactory = new MessageFactory();
            MessageTable<Message> instanceMessage = (MessageTable<Message>)messageFactory.GetMessageInstance();
            instanceMessage.Delete(id);
            return "OK";
        }
    }
}
