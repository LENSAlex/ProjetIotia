using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// Salle et une class qui est utiliser pour recupére les valuer des requette Get  d'un salle
    /// </summary>
    public class Salle
    {
        /// <summary>
        /// Recupére le parametre id_salle dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_salle")]
        public int IdSalle { get; set; }

        /// <summary>
        /// Recupére le parametre nom dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomBatiment { get; set; }
    }
}
