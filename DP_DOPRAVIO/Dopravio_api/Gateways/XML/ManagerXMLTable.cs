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
    public class ManagerXMLTable<T> : ManagerGatewayInterface<T>
          where T : Manager
    {
        private static ManagerXMLTable<Manager> instance;
        private ManagerXMLTable() { }

        public static ManagerXMLTable<Manager> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManagerXMLTable<Manager>();
                }
                return instance;
            }
        }

        public XElement Insert(Manager obj)
        {
            XElement result = new XElement("Manager",
                new XAttribute("id", obj.id),
                new XAttribute("name", obj.name),
                new XAttribute("surname", obj.surname),
                new XAttribute("dateOfBirth", obj.dateOfBirth),
                new XAttribute("phone", obj.phone),
                new XAttribute("email", obj.email),
                new XAttribute("password", obj.password),
                new XAttribute("address", obj.address),
                new XAttribute("salary", obj.salary));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> managers = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Managers").Descendants("Manager").ToList();
            foreach (var element in elements)
            {
                Manager manager = new Manager();
                manager.id = int.Parse(element.Attribute("id").Value);
                manager.name = element.Attribute("name").Value;
                manager.surname = element.Attribute("surname").Value;
                manager.dateOfBirth = DateTime.Parse(element.Attribute("dateOfBirth").Value);
                manager.phone = element.Attribute("phone").Value;
                manager.email = element.Attribute("email").Value;
                manager.password = element.Attribute("password").Value;
                manager.address = element.Attribute("address").Value;
                manager.salary = decimal.Parse(element.Attribute("salary").Value);

                managers.Add((T)manager);
            }

            return managers;
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