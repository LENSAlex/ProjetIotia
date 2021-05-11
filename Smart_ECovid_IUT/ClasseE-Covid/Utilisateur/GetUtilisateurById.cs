using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Utilisateur
{
    public class GetUtilisateurById
    {
        [JsonPropertyName("id_personne")]
        public static int? Id { get; set; }
    }
}
