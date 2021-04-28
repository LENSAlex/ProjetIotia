using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    public class Salle
    {
        [JsonPropertyName("id_salle")]
        public int IdSalle { get; set; }

        [JsonPropertyName("nom")]
        public string NomBatiment { get; set; }
    }
}
