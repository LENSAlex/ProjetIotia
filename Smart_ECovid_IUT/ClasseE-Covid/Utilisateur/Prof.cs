using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClasseE_Covid.Utilisateur.Manager;

namespace ClasseE_Covid.Utilisateur
{
    /// <summary>
    /// Prof et une class qui est utiliser pour recupére les valuer des requette Get sur Professeur 
    /// </summary>
    public class Prof
    {

        ManagerUtilisateur managerUtilisateur;

        /// <summary>
        /// Recupére le parametre id_professeur  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_professeur")]
        public int IdProf { get; set; }

        /// <summary>
        /// Recupére le parametre nom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomProf { get; set; }

        /// <summary>
        /// Recupére le parametre prenom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("prenom")]
        public string PrenomProf { get; set; }
    }
}
