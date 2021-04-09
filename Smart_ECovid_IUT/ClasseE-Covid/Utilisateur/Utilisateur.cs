using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Utilisateur
{
    public class Utilisateur
    {
        [JsonPropertyName("id_personne")]
        public int Id { get; set; }

        [JsonPropertyName("num_ref")]
        public string NumRef { get; set; }

        [JsonPropertyName("id_pers_type")]
        public int IdPersType { get; set; }

        [JsonPropertyName("password")]
        public string Pwd { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("telephone")]
        public  string Telephone { get; set; }

        [JsonPropertyName("sexe")]
        public string Sexe { get; set; }

        [JsonPropertyName("NomFormation")]
        public string NomFormation { get; set; }

        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [JsonPropertyName("prenom")]
        public string Prenom { get; set; }

        [JsonPropertyName("date_anniversaire")]
        public DateTime Anniv { get; set; }

        [JsonPropertyName("libelle")]
        public string Niveau { get; set; }
    }
}
