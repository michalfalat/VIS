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
    public class DispatcherXMLTable<T> : DispatcherGatewayInterface<T>
          where T : Dispatcher
    {
        private static DispatcherXMLTable<Dispatcher> instance;
        private DispatcherXMLTable() { }

        public static DispatcherXMLTable<Dispatcher> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DispatcherXMLTable<Dispatcher>();
                }
                return instance;
            }
        }

        public XElement Insert(Dispatcher obj)
        {
            XElement result = new XElement("Dispatcher",
                new XAttribute("id", obj.id),
                new XAttribute("name", obj.name),
                new XAttribute("surname", obj.surname),
                new XAttribute("dateOfBirth", obj.dateOfBirth),
                new XAttribute("phone", obj.phone),
                new XAttribute("email", obj.email),
                new XAttribute("password", obj.password),
                new XAttribute("address", obj.address),
                new XAttribute("salary", obj.salary),
                new XAttribute("skills", obj.skills));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> dispatchers = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Dispatchers").Descendants("Dispatcher").ToList();
            foreach (var element in elements)
            {
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.id = int.Parse(element.Attribute("id").Value);
                dispatcher.name = element.Attribute("name").Value;
                dispatcher.surname = element.Attribute("surname").Value;
                dispatcher.dateOfBirth = DateTime.Parse(element.Attribute("dateOfBirth").Value);
                dispatcher.phone = element.Attribute("phone").Value;
                dispatcher.email = element.Attribute("email").Value;
                dispatcher.password = element.Attribute("password").Value;
                dispatcher.address = element.Attribute("address").Value;
                dispatcher.salary = decimal.Parse(element.Attribute("salary").Value);
                dispatcher.skills = int.Parse(element.Attribute("skills").Value);

                dispatchers.Add((T)dispatcher);
            }

            return dispatchers;
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