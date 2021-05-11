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

        [JsonPropertyName("id_promotion")]
        public int Id { get; set; }

        [JsonPropertyName("id_professeur")]
        public int IdProf { get; set; }

        [JsonPropertyName("prenom")]
        public string PernomProf { get; set; }

        [JsonPropertyName("nomProf")]
        public string NomProf { get; set; }

    }
}
