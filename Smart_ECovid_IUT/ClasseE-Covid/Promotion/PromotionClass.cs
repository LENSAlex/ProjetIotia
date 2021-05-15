using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Promotion
{
    /// <summary>
    /// PromotionClass et une class qui est utiliser pour recupére les valuer des requette Get sur Promotion Class
    /// </summary>
    public class PromotionClass
    {
        /// <summary>
        /// Recupére le parametre nom  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        /// <summary>
        /// Recupére le parametre annee  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("annee")]
        public int Annee { get; set; }

        /// <summary>
        /// Recupére le parametre duree  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("duree")]
        public int Duree { get; set; }

        /// <summary>
        /// Recupére le parametre id_promotion  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_promotion")]
        public int Id { get; set; }

        /// <summary>
        /// Recupére le parametre id_professeur  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_professeur")]
        public int IdProf { get; set; }

        /// <summary>
        /// Recupére le parametre prenom dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("prenom")]
        public string PernomProf { get; set; }

        /// <summary>
        /// Recupére le parametre nomProf  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nomProf")]
        public string NomProf { get; set; }

    }
}
