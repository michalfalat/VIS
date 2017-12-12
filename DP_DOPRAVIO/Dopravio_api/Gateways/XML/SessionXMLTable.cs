using Dopravio.Database;
using Dopravio.Models;
using Dopravio_api.Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dopravio_api.Gateways.XML
{
    public class SessionXMLTable<T> : SessionGatewayInterface<T>
          where T : Session
    {
        private static SessionXMLTable<Session> instance;
        private SessionXMLTable() { }

        public static SessionXMLTable<Session> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionXMLTable<Session>();
                }
                return instance;
            }
        }

        public void Insert(Session obj)
        {
            XDocument doc = XDocument.Load(Configuration.XMLFILEPATH);
            XElement result = new XElement("Session",
                new XAttribute("token", obj.token),
                new XAttribute("type", obj.type),
                new XAttribute("userId", obj.user_id));

            doc.Element("Sessions").Add(result);
            doc.Save(Configuration.XMLFILEPATH);
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> sessions = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Sessions").Descendants("Session").ToList();
            foreach (var element in elements)
            {
                Session session = new Session();
                session.token = element.Attribute("token").Value;
                session.type = element.Attribute("type").Value;
                session.user_id = int.Parse(element.Attribute("userId").Value);
                sessions.Add((T)session);
            }

            return sessions;
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

        public Dispatcher SelectDispatcherSession(string token)
        {
            throw new NotImplementedException();
        }

        public Driver SelectDriverSession(string token)
        {
            throw new NotImplementedException();
        }

        public Manager SelectManagerSession(string token)
        {
            throw new NotImplementedException();
        }
    }
}