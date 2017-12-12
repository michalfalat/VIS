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
    class RoutesConnector : IConnector<Route>
    {

        public static String URL = "http://localhost:64846/api/routes";



        public List<Route> get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Route> routes = JsonConvert.DeserializeObject<List<Route>>(responseString);
            return routes;
        }

        public Route get(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL + $"/{id}");
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Route route = JsonConvert.DeserializeObject<Route>(responseString);
            return route;
        }

        public string update(Route obj)
        {
            throw new NotImplementedException();
        }

        public string delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
