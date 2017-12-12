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
    public class VehicleXMLTable<T> : VehicleGatewayInterface<T>
          where T : Vehicle
    {
        private static VehicleXMLTable<Vehicle> instance;
        private VehicleXMLTable() { }

        public static VehicleXMLTable<Vehicle> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleXMLTable<Vehicle>();
                }
                return instance;
            }
        }

        public void Insert(Vehicle obj)
        {
            XDocument doc = XDocument.Load(Configuration.XMLFILEPATH);
          
            XElement result = new XElement("Vehicle",
                new XAttribute("id", obj.id),
                new XAttribute("name", obj.name),
                new XAttribute("year", obj.year),
                new XAttribute("capacity", obj.capacity),
                new XAttribute("consumption", obj.consumption));

            doc.Element("Vehicles").Add(result);
            doc.Save(Configuration.XMLFILEPATH);

            //return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> vehicles = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Vehicles").Descendants("Vehicle").ToList();
            foreach (var element in elements)
            {
                Vehicle vehicle = new Vehicle();
                vehicle.id = int.Parse(element.Attribute("id").Value);
                vehicle.name = element.Attribute("name").Value;
                vehicle.year = int.Parse(element.Attribute("year").Value);
                vehicle.capacity = int.Parse(element.Attribute("capacity").Value);
                vehicle.consumption = decimal.Parse(element.Attribute("consumption").Value);

                vehicles.Add((T)vehicle);
            }

            return vehicles;
        }

        public T Select(int id)
        {
            var list = this.Select();
            foreach(var item in list)
            {
                if(item.id == id)
                {
                    return item;
                }
            }
            return null;
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