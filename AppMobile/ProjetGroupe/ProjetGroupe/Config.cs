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
    /// <summary>
    /// Classe de configuration de l'application
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Base de données
        /// </summary>
        public static string ConnectionString { get; set; }
        /// <summary>
        /// Endpoint
        /// </summary>
        public static string NotificationEndPoint { get; set; }
        /// <summary>
        /// HubName
        /// </summary>
        public static string NotificationHubName { get; set; }
        /// <summary>
        /// ChannelID
        /// </summary>
        public static string NotificationChannelID { get; set; }
        /// <summary>
        /// Mail send
        /// </summary>
        public static string Mail { get; set; }
        /// <summary>
        /// Mail To
        /// </summary>
        public static string MailTo { get; set; }
        /// <summary>
        /// Mot de passe du compte de mail
        /// </summary>
        public static string MailPw { get; set; }
        /// <summary>
        /// Serveur de mail
        /// </summary>
        public static string MailServer { get; set; }
        /// <summary>
        /// Port du serveur de mail
        /// </summary>
        public static string MailPort { get; set; }
        /// <summary>
        /// Uri de l'API REST
        /// </summary>
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
    /// <summary>
    /// Classe RestService
    /// </summary>
    public class RestService
    {
        HttpClient _client;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
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
