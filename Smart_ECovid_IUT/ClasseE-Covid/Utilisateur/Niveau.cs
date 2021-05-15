using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Utilisateur
{
    /// <summary>
    /// Niveau et une class qui est utiliser pour recupére les valuer des requette Get sur Niveau 
    /// </summary>
    public class Niveau
    {
        /// <summary>
        /// Recupére le parametre id_pers_type  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_pers_type")]
        public int IdNiveau { get; set; }

        /// <summary>
        /// Recupére le parametre libelle  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string LeNiveau { get; set; }
    }
}
