using Dopravio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Helpers
{
    class TimetablesConnector : IConnector<Timetable>
    {

        public static String URL = "http://localhost:64846/api/timetables";



        public List<Timetable> get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Timetable> timetables = JsonConvert.DeserializeObject<List<Timetable>>(responseString);
            return timetables;
        }

        public Timetable get(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL + $"/{id}");
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Timetable timetable = JsonConvert.DeserializeObject<Timetable>(responseString);
            return timetable;
        }

        public string update(Timetable obj)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(URL+"/" + obj.id));
            http.Headers.Add("token", Authorization.loginResponse.token);
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "PUT";

            string parsedContent = JsonConvert.SerializeObject(obj, Formatting.Indented);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;
        }

        public string delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
