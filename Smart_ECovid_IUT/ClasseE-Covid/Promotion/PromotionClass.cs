using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Promotion
{
    public class PromotionClass
    {
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [JsonPropertyName("annee")]
        public int Annee { get; set; }

        [JsonPropertyName("duree")]
        public int Duree { get; set; }
    }
}
