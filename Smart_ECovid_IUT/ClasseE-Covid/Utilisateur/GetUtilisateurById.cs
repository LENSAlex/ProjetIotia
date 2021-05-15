using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Utilisateur
{
    /// <summary>
    /// GetUtilisateurById et une class qui est utiliser pour recupére les valuer des requette Get avec un parametre sur un utilisateur 
    /// </summary>
    public class GetUtilisateurById
    {
        /// <summary>
        /// Recupére le parametre id_personne  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_personne")]
        public static int? Id { get; set; }
    }
}
