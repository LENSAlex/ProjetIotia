using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    /// <summary>
    /// TypeCapteur et une class qui est utiliser pour recupére les valuer des requette Get sur les Type de Capteur
    /// </summary>
    public class ValeurCapteur
    {
        /// <summary>
        /// Recupére le parametre id_valuetype dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_valuetype")]
        public int IdValuetype { get; set; }

        /// <summary>
        /// Recupére le parametre libelle (Nom Valuetype) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string NomValuetype { get; set; }

        /// <summary>
        /// Recupére le parametre unite  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("unite")]
        public string UniterValuetype { get; set; }
    }
}
