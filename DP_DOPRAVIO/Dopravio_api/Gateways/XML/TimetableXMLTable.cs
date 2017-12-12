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
    public class TimetableXMLTable<T> : TimetableGatewayInterface<T>
          where T : Timetable
    {
        private static TimetableXMLTable<Timetable> instance;
        private TimetableXMLTable() { }

        public static TimetableXMLTable<Timetable> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimetableXMLTable<Timetable>();
                }
                return instance;
            }
        }

        public XElement Insert(Timetable obj)
        {
            XElement result = new XElement("Timetable",
                new XAttribute("id", obj.id),
                new XAttribute("name", obj.name),
                new XAttribute("departure", obj.departure),
                new XAttribute("arrival", obj.arrival),
                new XAttribute("routeId", obj.route.id),
                new XAttribute("driverId", obj.driver.id),
                new XAttribute("vehicleId", obj.vehicle.id));

            return result;
        }

        public Collection<T> Select()
        {
            RouteFactory routeFactory = new RouteFactory();
            RouteTable<Route> instanceRoute = (RouteTable<Route>)routeFactory.GetRouteInstance();

            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();

            VehicleFactory vehicleFactory = new VehicleFactory();
            VehicleTable<Vehicle> instanceVehicle = (VehicleTable<Vehicle>)vehicleFactory.GetVehicleInstance();


            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> timetables = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Timetables").Descendants("Timetable").ToList();
            foreach (var element in elements)
            {
                Timetable timetable = new Timetable();
                timetable.id = int.Parse(element.Attribute("id").Value);
                timetable.name = element.Attribute("name").Value;
                timetable.departure = DateTime.Parse(element.Attribute("departure").Value);
                timetable.arrival = DateTime.Parse(element.Attribute("arrival").Value);
                timetable.route = instanceRoute.Select(int.Parse(element.Attribute("routeId").Value));
                timetable.driver = instanceDriver.Select(int.Parse(element.Attribute("driverId").Value));
                timetable.vehicle = instanceVehicle.Select(int.Parse(element.Attribute("vehicleId").Value));

                timetables.Add((T)timetable);
            }

            return timetables;
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