using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetGroupe.Views;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProjetGroupe
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        static Config()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resName = assembly.GetManifestResourceNames()?.FirstOrDefault(r => r.EndsWith("appsettings.json", StringComparison.OrdinalIgnoreCase));
            var file = assembly.GetManifestResourceStream(resName);
            var sr = new StreamReader(file);
            var json = sr.ReadToEnd();
            var j = JToken.Parse(json);
            ConnectionString = j.SelectToken("MainDatabase").ToString();
        }
    }
}
