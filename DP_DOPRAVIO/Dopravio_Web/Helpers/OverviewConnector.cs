using Dopravio.Helpers;
using Dopravio_api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Dopravio_Web.Helpers
{
    class OverviewConnector : IConnector<Overview>
    {

        public static String URL = "http://localhost:64846/api/overview";

        public string delete(int id)
        {
            throw new NotImplementedException();
        }

        public Overview getOverview()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Dopravio.Helpers.Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Overview o = JsonConvert.DeserializeObject<Overview>(responseString);
            return o;
        }

        public List<Overview> get()
        {
            throw new NotImplementedException();
        }

        public Overview get(int id)
        {
            throw new NotImplementedException();
        }

        public string update(Overview obj)
        {
            throw new NotImplementedException();
        }
    }

}