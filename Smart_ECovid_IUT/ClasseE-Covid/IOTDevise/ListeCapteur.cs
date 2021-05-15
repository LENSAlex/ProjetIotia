using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.IOTDevise
{
    /// <summary>
    /// ListeCapteur et une class qui est utiliser pour recupére les valuer des requette Get des Liste apteur
    /// </summary>
    public class ListeCapteur
    {
        /// <summary>
        /// Recupére le parametre id_device  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_device")]
        public int IdCapteur { get; set; }

        /// <summary>
        /// Recupére le parametre libelle_type (Nom Capteur)  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle_type")]
        public string NomCapteur { get; set; }

        /// <summary>
        /// Recupére le parametre libelle (Nom Box)  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }
    }
}
