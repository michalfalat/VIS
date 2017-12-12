using Dopravio.Models;
using Dopravio_api.Models;
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
    class MessagesConnector : IConnector<Message>
    {

        public static String URL = "http://localhost:64846/api/messages";



        public List<Message> get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Headers.Add("token", Authorization.loginResponse.token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(responseString);
            return messages;
        }

        public Message get(int id)
        {

            throw new NotImplementedException();
        }

        public string send(Message obj)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(URL));
            http.Headers.Add("token", Authorization.loginResponse.token);
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

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
            var http = (HttpWebRequest)WebRequest.Create(new Uri(URL+ "/" + id));
            http.Headers.Add("token", Authorization.loginResponse.token);
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "DELETE";

            
            Stream newStream = http.GetRequestStream();
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;
        }

        public string update(Message obj)
        {
            throw new NotImplementedException();
        }
    }
}
