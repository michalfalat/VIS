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
    public class RouteXMLTable<T> : RouteGatewayInterface<T>
          where T : Route
    {
        private static RouteXMLTable<Route> instance;
        private RouteXMLTable() { }

        public static RouteXMLTable<Route> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RouteXMLTable<Route>();
                }
                return instance;
            }
        }

        public XElement Insert(Route obj)
        {
            XElement result = new XElement("Route",
                new XAttribute("id", obj.id),
                new XAttribute("start", obj.start),
                new XAttribute("finish", obj.finish),
                new XAttribute("distance", obj.distance));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> routes = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Routes").Descendants("Route").ToList();
            foreach (var element in elements)
            {
                Route route = new Route();
                route.id = int.Parse(element.Attribute("id").Value);
                route.start = element.Attribute("start").Value;
                route.finish = element.Attribute("finish").Value;
                route.distance = decimal.Parse(element.Attribute("distance").Value);

                routes.Add((T)route);
            }

            return routes;
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