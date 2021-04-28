using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    public class Energie
    {
        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        [JsonPropertyName("valeur")]
        public int ValeurEnergie { get; set; }

    }
}
