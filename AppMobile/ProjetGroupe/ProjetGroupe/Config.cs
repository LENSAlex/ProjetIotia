using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetGroupe.Views;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Xamarin.Forms;

namespace ProjetGroupe
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string NotificationEndPoint { get; set; }
        public static string NotificationHubName { get; set; }
        public static string NotificationChannelID { get; set; }

        public static string Mail { get; set; }
        public static string MailTo { get; set; }
        public static string MailPw { get; set; }
        public static string MailServer { get; set; }
        public static string MailPort { get; set; }
        public static string WebServiceURI { get; set; }
        static Config()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resName = assembly.GetManifestResourceNames()?.FirstOrDefault(r => r.EndsWith("appsettings.json", StringComparison.OrdinalIgnoreCase));
            var file = assembly.GetManifestResourceStream(resName);
            var sr = new StreamReader(file);
            var json = sr.ReadToEnd();
            var j = JToken.Parse(json);

            ConnectionString = j.SelectToken("MainDatabase").ToString();
            NotificationEndPoint = j.SelectToken("NotificationEndPoint").ToString();
            NotificationHubName = j.SelectToken("NotificationHubName").ToString();
            NotificationChannelID = j.SelectToken("NotificationChannelID").ToString();
            WebServiceURI = j.SelectToken("WebServiceURI").ToString();

            Mail = j.SelectToken("Mail").ToString();
            MailTo = j.SelectToken("MailTo").ToString();
            MailPw = j.SelectToken("MailPw").ToString();
            MailServer = j.SelectToken("MailServer").ToString();
            MailPort = j.SelectToken("MailPort").ToString();
        }
    }
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();

            if (Device.RuntimePlatform == Device.Android)
            {
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
