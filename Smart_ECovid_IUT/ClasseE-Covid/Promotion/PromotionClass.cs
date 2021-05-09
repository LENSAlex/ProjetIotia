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

        //[JsonPropertyName("nom")]
        //public string nomProf { get; set; }

        //[JsonPropertyName("prenom")]
        //public string pernomProf { get; set; }

        //[JsonPropertyName("id")]
        //public int IdProf { get; set; }

        //[JsonPropertyName("prenom")]
        //public string Departemnt { get; set; }

        //[JsonPropertyName("id")]
        //public int IdDepartemnt { get; set; }

    }
}
