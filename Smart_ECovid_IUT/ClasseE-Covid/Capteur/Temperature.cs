using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    public class Temperature
    {
        [JsonPropertyName("libelle_type")]
        public string NomTemp { get; set; }

        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        [JsonPropertyName("valeur")]
        public int ValeurTemp { get; set; }

    }
}
