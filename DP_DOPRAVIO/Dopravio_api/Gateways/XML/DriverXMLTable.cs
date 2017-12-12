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
    public class DriverXMLTable<T> : DriverGatewayInterface<T>
          where T : Driver
    {
        private static DriverXMLTable<Driver> instance;
        private DriverXMLTable() { }

        public static DriverXMLTable<Driver> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DriverXMLTable<Driver>();
                }
                return instance;
            }
        }

        public XElement Insert(Driver obj)
        {
            XElement result = new XElement("Driver",
                new XAttribute("id", obj.id),
                new XAttribute("name", obj.name),
                new XAttribute("surname", obj.surname),
                new XAttribute("dateOfBirth", obj.dateOfBirth),
                new XAttribute("phone", obj.phone),
                new XAttribute("email", obj.email),
                new XAttribute("password", obj.password),
                new XAttribute("address", obj.address),
                new XAttribute("salary", obj.salary),
                new XAttribute("accidentCount", obj.accidentCount));

            return result;
        }

       public  Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> drivers = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Drivers").Descendants("Driver").ToList();
            foreach (var element in elements)
            {
                Driver driver = new Driver() ;
                driver.id = int.Parse(element.Attribute("id").Value);
                driver.name = element.Attribute("name").Value;
                driver.surname = element.Attribute("surname").Value;
                driver.dateOfBirth =  DateTime.Parse( element.Attribute("dateOfBirth").Value);
                driver.phone = element.Attribute("phone").Value;
                driver.email = element.Attribute("email").Value;
                driver.password = element.Attribute("password").Value;
                driver.address = element.Attribute("address").Value;
                driver.salary = decimal.Parse(element.Attribute("salary").Value);
                driver.accidentCount = int.Parse(element.Attribute("accidentCount").Value);
                
                drivers.Add((T)driver);
            }

            return drivers;
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