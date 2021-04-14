using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.LogAlerte
{
    public class LogAlerte
    {
        [JsonPropertyName("nom")]
        public string nomCasCovid { get; set; }

        [JsonPropertyName("prenom")]
        public string prenomCasCovid { get; set; }

        [JsonPropertyName("date_declaration")]
        public string DateCasCovid { get; set; }

        [JsonPropertyName("name")]
        public string PromoCasCovid { get; set; }

        [JsonPropertyName("NbCasCovid")]
        public int NbCasCovid { get; set; }
    }
}
