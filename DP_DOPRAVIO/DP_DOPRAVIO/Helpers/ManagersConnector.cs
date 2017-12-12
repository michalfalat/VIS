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
    class ManagersConnector : IConnector<Manager>
    {

        public static String URL = "http://localhost:64846/api/manager";



        public List<Manager> get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Manager> managers = JsonConvert.DeserializeObject<List<Manager>>(responseString);
            return managers;
        }

        public Manager get(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL + $"/{id}");
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Manager manager = JsonConvert.DeserializeObject<Manager>(responseString);
            return manager;
        }

        public string update(Manager obj)
        {
            throw new NotImplementedException();
        }

        public string delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
