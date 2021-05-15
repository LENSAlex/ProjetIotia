using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// OccupationBatiment et une class qui est utiliser pour recupére les valuer des requette Get  d'un taux d'Occupation Batiment
    /// </summary>
    public class OccupationBatiment
    {
        /// <summary>
        /// Recupére le parametre id_batiment dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_batiment")]
        public int IdBatiment { get; set; }

        /// <summary>
        /// Recupére le parametre nom batiment dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomBatiment { get; set; }

        /// <summary>
        /// Recupére le parametre taux_occupation dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("taux_occupation")]
        public decimal TauxOccupation { get; set; }

        /// <summary>
        /// Recupére le parametre capacite_max_batiment dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("capacite_max_batiment")]
        public int CapaciteMaxBat { get; set; }
    }
}
