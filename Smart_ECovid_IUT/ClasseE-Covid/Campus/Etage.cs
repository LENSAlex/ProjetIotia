using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    public class Etage
    {
        
        [JsonPropertyName("id_etage")]
        public int IdEtage { get; set; }

        [JsonPropertyName("nom")]
        public string NomBatiment { get; set; }

        [JsonPropertyName("num")]
        public string NumEtage { get; set; }

    }
}
