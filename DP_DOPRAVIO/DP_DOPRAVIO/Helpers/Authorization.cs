using Dopravio_api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Helpers
{
    class Authorization
    {
        public static LoginResponse loginResponse = null;
        public static string URL_LOGIN = "http://localhost:64846/api/login";
        public static string URL_LOGOUT = "http://localhost:64846/api/logout";
        class User
        {
            public User(string email, string password)
            {
                this.email = email;
                this.password = password;
            }
            public string email { get; set; }
            public string password { get; set; }
        }

        public static LoginResponse Login(string email, string password)
        {
            User u = new User(email, password);
            using (var client = new WebClient())
            {
                //client.
                //var values = new NameValueCollection();
                //values["email"] = email;
                //values["password"] = password;

                var http = (HttpWebRequest)WebRequest.Create(new Uri(URL_LOGIN));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";

                string parsedContent = JsonConvert.SerializeObject(u, Formatting.Indented);
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(parsedContent);

                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                LoginResponse lr = JsonConvert.DeserializeObject<LoginResponse>(responseString);
                loginResponse = lr;
                return lr;
            }
        }


        public static string Logout()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL_LOGOUT);
            request.Method = "POST";
            request.Headers.Add("token", Authorization.loginResponse.token);
            request.ContentLength = 0;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            loginResponse = null;
            return "";
        }

        public static string GetURL(string url)
        {
            return loginResponse.type.ToLower() + "/" + url;
        }
    }
}
