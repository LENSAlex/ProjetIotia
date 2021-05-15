using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.LogAlerte
{
    /// <summary>
    /// LogAlerte et une class qui est utiliser pour recupére les valuer des requette Get sur Alert des cas covid
    /// </summary>
    public class LogAlerte
    {
        /// <summary>
        /// Recupére le parametre nom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string nomCasCovid { get; set; }

        /// <summary>
        /// Recupére le parametre prenom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("prenom")]
        public string prenomCasCovid { get; set; }

        /// <summary>
        /// Recupére le parametre date_declaration dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("date_declaration")]
        public string DateCasCovid { get; set; }

        /// <summary>
        /// Recupére le parametre name dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("name")]
        public string PromoCasCovid { get; set; }

        /// <summary>
        /// Recupére le parametre NbCasCovid dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NbCasCovid")]
        public int NbCasCovid { get; set; }
    }
}
