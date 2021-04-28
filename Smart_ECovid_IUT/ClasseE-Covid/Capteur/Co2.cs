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
    }
}
