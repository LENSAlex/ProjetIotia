using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MediaSense
{
    public class Config
    {
        private static IConfigurationRoot _configuration;

        static Config()
        {

            ConfigurationBuilder _configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            _configurationBuilder.AddJsonFile(path, false);

            _configuration = _configurationBuilder.Build();
        }

        //Récupère une valeur du fichier de configuration (attend une clé en paramètre)
        public static string GetConfig(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        //Retourne la chaîne de connection à la base de données
        public static string ConnectionString {
            get => GetConfig("ConnectionStrings:MainDatabase");
        }

        public static string SmtpMdp {
            get => GetConfig("Email:MdpSmtp");
        }
        public static string SmtpUser {
            get => GetConfig("Email:UserSmtp");
        }

        public static string SmtpHost {
            get => GetConfig("Email:HostSmtp");
        }

        public static string SmtpPort {
            get => GetConfig("Email:PortSmtp");
        }

        public static string SmtpEmailTo {
            get => GetConfig("Email:To");
        }

        public static string SmtpEmailFrom {
            get => GetConfig("Email:From");
        }

        public static string SmtpEmailBcc {
            get => GetConfig("Email:Bcc");
        }
    }
}
