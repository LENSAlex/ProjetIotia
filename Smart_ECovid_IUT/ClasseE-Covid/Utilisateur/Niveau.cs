using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Utilisateur
{
    public class Niveau
    {
        [JsonPropertyName("id_pers_type")]
        public int IdNiveau { get; set; }

        [JsonPropertyName("libelle")]
        public string LeNiveau { get; set; }
    }
}
