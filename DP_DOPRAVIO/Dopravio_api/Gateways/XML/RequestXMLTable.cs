using Dopravio.Database;
using Dopravio.Models;
using Dopravio_api.Config;
using Dopravio_api.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dopravio_api.Gateways.XML
{
    public class RequestXMLTable<T> : RequestGatewayInterface<T>
          where T : Request
    {
        private static RequestXMLTable<Request> instance;
        private RequestXMLTable() { }

        public static RequestXMLTable<Request> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RequestXMLTable<Request>();
                }
                return instance;
            }
        }

        public XElement Insert(Request obj)
        {
            XElement result = new XElement("Request",
                new XAttribute("id", obj.id),
                new XAttribute("state", (int)obj.state),
                new XAttribute("type", (int)obj.type),
                new XAttribute("priority", obj.priority),
                new XAttribute("created", obj.created),
                new XAttribute("message", obj.message),
                new XAttribute("resultMessage", obj.resultMessage),
                new XAttribute("dispatcherId", obj.dispatcher.id));

            return result;
        }

        public Collection<T> Select()
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();

            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> requests = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Requests").Descendants("Request").ToList();
            foreach (var element in elements)
            {
                Request request = new Request();
                request.id = int.Parse(element.Attribute("id").Value);
                request.state = (RequestState)int.Parse(element.Attribute("state").Value);
                request.type = (RequestType)int.Parse(element.Attribute("type").Value);
                request.priority = int.Parse(element.Attribute("priority").Value);
                request.created = DateTime.Parse(element.Attribute("created").Value);
                request.message = element.Attribute("message").Value;
                request.resultMessage = element.Attribute("resultMessage").Value;
                request.dispatcher = instanceDispatcher.Select(int.Parse(element.Attribute("dispatcherId").Value));
                
                requests.Add((T)request);
            }

            return requests;
        }

        public T Select(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}