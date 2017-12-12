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
    class DriversConnector : IConnector<Driver>
    {

        public static String URL = "http://localhost:64846/api/drivers";



        public List<Driver> get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Driver> drivers = JsonConvert.DeserializeObject<List<Driver>>(responseString);
            return drivers;
        }

        public Driver get(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL + $"/{id}");
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Driver driver = JsonConvert.DeserializeObject<Driver>(responseString);
            return driver;
        }

        public string update(Driver obj)
        {
            throw new NotImplementedException();
        }

        public string delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
