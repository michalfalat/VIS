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
    class DispatchersConnector : IConnector<Dispatcher>
    {

        public static String URL = "http://localhost:64846/api/dispatchers";



        public List<Dispatcher> get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Dispatcher> dispatchers = JsonConvert.DeserializeObject<List<Dispatcher>>(responseString);
            return dispatchers;
        }

        public Dispatcher get(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL + $"/{id}");
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Dispatcher dispatcher = JsonConvert.DeserializeObject<Dispatcher>(responseString);
            return dispatcher;
        }

        public string update(Dispatcher obj)
        {
            throw new NotImplementedException();
        }

        public string delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
