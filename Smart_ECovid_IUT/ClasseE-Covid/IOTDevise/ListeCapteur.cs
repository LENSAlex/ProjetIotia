using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.IOTDevise
{
    public class ListeCapteur
    {
        [JsonPropertyName("id_device")]
        public int IdCapteur { get; set; }

        [JsonPropertyName("libelle_type")]
        public string NomCapteur { get; set; }

        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }
    }
}
