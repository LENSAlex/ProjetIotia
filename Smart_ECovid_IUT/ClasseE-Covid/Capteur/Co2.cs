using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    public class Co2
    {
        [JsonPropertyName("libelle_type")]
        public string NomCo2 { get; set; }

        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        [JsonPropertyName("valeur")]
        public int ValeurCo2 { get; set; }

        [JsonPropertyName("NomSalle")]
        public string NomSalle { get; set; }

        [JsonPropertyName("NomEtage")]
        public string NomEtage { get; set; }

        [JsonPropertyName("NomBatiment")]
        public string NomBatiment { get; set; }

        [JsonPropertyName("NomSite")]
        public string NomSite { get; set; }

        [JsonPropertyName("date_historique")]
        public DateTime Date { get; set; }
    }
}
