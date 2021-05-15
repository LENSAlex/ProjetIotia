using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe
{
    public static partial class Configuration
    {
        static Configuration()
        {
            BackendServiceEndpoint = "https://projetcovid.azurewebsites.net/";
        }
    }
}
