using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    public class Campus
    {

        /// <summary>
        /// liste campus
        /// </summary>
        [JsonPropertyName("id_site")]
        public int IdCampus { get; set; }

        [JsonPropertyName("nbetage")]
        public int NBEtageCampus { get; set; }

        [JsonPropertyName("nom")]
        public string NomCampus { get; set; }

        [JsonPropertyName("nbsalle")]
        public int NBSalleCampus { get; set; }


        /// <summary>
        /// liste Batiment
        /// </summary>

        [JsonPropertyName("id_batiment")]
        public int IdBatiment { get; set; }

        //[JsonPropertyName("id_site")]
        //public int IdCampusBatiment { get; set; }

        [JsonPropertyName("NomBatiment")]
        public string NomBatimen { get; set; }


        /// <summary>
        /// liste Etage
        /// </summary>
        [JsonPropertyName("id_etage")]
        public int IdEtage { get; set; }

        [JsonPropertyName("nomff")]
        public string NomBatEtage { get; set; }

        [JsonPropertyName("num")]
        public int NumEtage { get; set; }


        /// <summary>
        /// variavle Post
        /// </summary>

    }
}
