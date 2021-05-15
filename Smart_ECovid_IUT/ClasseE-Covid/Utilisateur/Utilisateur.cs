using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Utilisateur
{
    /// <summary>
    /// Utilisateur et une class qui est utiliser pour recupére les valuer des requette Get avec un parametre sur utilisateur 
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// Recupére le parametre id_personne  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_personne")]
        public int? Id { get; set; }

        /// <summary>
        /// Recupére le parametre num_ref  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("num_ref")]
        public string NumRef { get; set; }

        /// <summary>
        /// Recupére le parametre id_pers_type  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_pers_type")]
        public int IdPersType { get; set; }

        /// <summary>
        /// Recupére le parametre password  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("password")]
        public string Pwd { get; set; }

        /// <summary>
        /// Recupére le parametre email  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Recupére le parametre telephone  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("telephone")]
        public  string Telephone { get; set; }

        /// <summary>
        /// Recupére le parametre sexe  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("sexe")]
        public string Sexe { get; set; }

        /// <summary>
        /// Recupére le parametre NomFormation  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomFormation")]
        public string NomFormation { get; set; }

        /// <summary>
        /// Recupére le parametre nom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        /// <summary>
        /// Recupére le parametre prenom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("prenom")]
        public string Prenom { get; set; }

        /// <summary>
        /// Recupére le parametre date_anniversaire  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("date_anniversaire")]
        public string Anniv { get; set; }

        /// <summary>
        /// Recupére le parametre libelle  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string Niveau { get; set; }

        /// <summary>
        /// Recupére le parametre IdPromo  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("IdPromo")]
        public int Promotion { get; set; }

    }
}
