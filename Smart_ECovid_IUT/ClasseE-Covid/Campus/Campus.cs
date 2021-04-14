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
        [JsonPropertyName("nbetage")]
        public int NBEtageCampus { get; set; }

        [JsonPropertyName("nom")]
        public string NomCampus { get; set; }

        [JsonPropertyName("nbsalle")]
        public int NBSalleCampus { get; set; }

        //[JsonPropertyName("nbetage")]
        //public int NBEtageCampus { get; set; }

        /// <summary>
        /// liste Batiment
        /// </summary>

        [JsonPropertyName("id_batiment")]
        public int IdBatiment { get; set; }

        [JsonPropertyName("id_site")]
        public int IdCampusBatiment { get; set; }

        //[JsonPropertyName("nom")]
        //public string NomduBatimen { get; set; }

    }
}
