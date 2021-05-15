using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    /// <summary>
    /// TypeCapteur et une class qui est utiliser pour recupére les valuer des requette Get sur les Type de Capteur
    /// </summary>
    public class TypeCapteur
    {
        /// <summary>
        /// Recupére le parametre id_devicetype dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_devicetype")]
        public int IdTypeDevice { get; set; }

        /// <summary>
        /// Recupére le parametre libelle_type (Nom Type Device) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle_type")]
        public string NomTypeDevice { get; set; }
    }
}
