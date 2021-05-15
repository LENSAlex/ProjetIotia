using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    /// <summary>
    /// Temperature et une class qui est utiliser pour recupére les valuer des requette Get sur la température
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// Recupére le parametre libelle_type (Nom capteur temp) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle_type")]
        public string NomTemp { get; set; }

        /// <summary>
        /// Recupére le parametre libelle (Nom Box) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        /// <summary>
        /// Recupére le parametre valeur  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("valeur")]
        public int ValeurTemp { get; set; }

    }
}
