using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// Etage et une class qui est utiliser pour recupére les valuer des requette Get l'aure de l'affichage des etages
    /// </summary>
    public class Etage
    {
        /// <summary>
        /// Recupére le parametre id_etage dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_etage")]
        public int IdEtage { get; set; }

        /// <summary>
        /// Recupére le parametre nom dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomBatiment { get; set; }

        /// <summary>
        /// Recupére le parametre num (numéro d'étage) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("num")]
        public string NumEtage { get; set; }

    }
}
