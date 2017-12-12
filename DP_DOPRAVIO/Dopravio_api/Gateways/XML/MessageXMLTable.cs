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
    public class MessageXMLTable<T> : MessageGatewayInterface<T>
          where T : Message
    {
        private static MessageXMLTable<Message> instance;
        private MessageXMLTable() { }

        public static MessageXMLTable<Message> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageXMLTable<Message>();
                }
                return instance;
            }
        }

        public XElement Insert(Message obj)
        {
            XElement result = new XElement("Message",
                new XAttribute("id", obj.id),
                new XAttribute("created", obj.created),
                new XAttribute("text", obj.text),
                new XAttribute("isRead", obj.isRead),
                new XAttribute("dispatcherId", obj.dispatcher.id),
                new XAttribute("managerId", obj.manager.id));

            return result;
        }

        public Collection<T> Select()
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();

            ManagerFactory managerFactory = new ManagerFactory();
            ManagerTable<Manager> instanceManager = (ManagerTable<Manager>)managerFactory.GetManagerInstance();

            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> messages = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Messages").Descendants("Message").ToList();
            foreach (var element in elements)
            {
                Message message = new Message();
                message.id = int.Parse(element.Attribute("id").Value);
                message.created = DateTime.Parse(element.Attribute("created").Value);
                message.text = element.Attribute("text").Value;
                message.isRead = bool.Parse(element.Attribute("isRead").Value);
                message.dispatcher = instanceDispatcher.Select(int.Parse( element.Attribute("dispatcherId").Value));
                message.manager = instanceManager.Select(int.Parse(element.Attribute("managerId").Value));
               

                messages.Add((T)message);
            }

            return messages;
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