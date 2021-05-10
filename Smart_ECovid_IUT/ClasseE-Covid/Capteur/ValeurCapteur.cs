using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    public class ValeurCapteur
    {
        [JsonPropertyName("id_valuetype")]
        public int IdValuetype { get; set; }

        [JsonPropertyName("libelle")]
        public string NomValuetype { get; set; }

        [JsonPropertyName("unite")]
        public string UniterValuetype { get; set; }
    }
}
