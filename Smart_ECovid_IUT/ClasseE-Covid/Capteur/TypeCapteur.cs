using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    public class TypeCapteur
    {
        [JsonPropertyName("id_devicetype")]
        public int IdTypeDevice { get; set; }

        [JsonPropertyName("libelle_type")]
        public string NomTypeDevice { get; set; }
    }
}
