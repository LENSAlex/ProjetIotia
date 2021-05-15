using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// OccupationSite et une class qui est utiliser pour recupére les valuer des requette Get  d'un taux d'Occupation Site
    /// </summary>
    public class OccupationSite
    {
        /// <summary>
        /// Recupére le parametre id_site dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_site")]
        public int IdSite { get; set; }

        /// <summary>
        /// Recupére le parametre nom site dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomSite { get; set; }

        /// <summary>
        /// Recupére le parametre taux_occupation dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("taux_occupation")]
        public decimal TauxOccupation { get; set; }

        /// <summary>
        /// Recupére le parametre capacite_max_site dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("capacite_max_site")]
        public int CapaciteMaxSite{ get; set;}
    }
}
