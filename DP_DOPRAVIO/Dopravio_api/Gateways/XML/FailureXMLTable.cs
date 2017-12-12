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
    public class FailureXMLTable<T> : FailureGatewayInterface<T>
          where T : Failure
    {
        private static FailureXMLTable<Failure> instance;
        private FailureXMLTable() { }

        public static FailureXMLTable<Failure> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FailureXMLTable<Failure>();
                }
                return instance;
            }
        }

        public XElement Insert(Failure obj)
        {
            XElement result = new XElement("Failure",
                new XAttribute("id", obj.id),
                new XAttribute("created", obj.created),
                new XAttribute("type",(int) obj.type),
                new XAttribute("place", obj.place),
                new XAttribute("severity", obj.severity),
                new XAttribute("message", obj.message),
                new XAttribute("resolved", obj.resolved),
                new XAttribute("timetableId", obj.timetable.id));

            return result;
        }

        public Collection<T> Select()
        {
            TimetableFactory timetableFactory = new TimetableFactory();
            TimetableTable<Timetable> instanceTimetable = (TimetableTable<Timetable>)timetableFactory.GetTimetableInstance();

            XDocument xDoc = XDocument.Load(Configuration.XMLFILEPATH);
            Collection<T> failures = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Failures").Descendants("Failure").ToList();
            foreach (var element in elements)
            {
                Failure failure = new Failure();
                failure.id = int.Parse(element.Attribute("id").Value);
                failure.created = DateTime.Parse(element.Attribute("created").Value);
                failure.type =  (FailureType) int.Parse(element.Attribute("type").Value);
                failure.place = element.Attribute("place").Value;
                failure.severity = int.Parse(element.Attribute("severity").Value);
                failure.message = element.Attribute("message").Value;
                failure.resolved = failure.created = DateTime.Parse(element.Attribute("resolved").Value);

                failure.timetable = instanceTimetable.Select(int.Parse(element.Attribute("timetableId").Value));
                failures.Add((T)failure);
            }

            return failures;
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