using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// Campus et une class qui est utiliser pour recupére les valuer des requette Get l'aure de l'affichage d'un campus
    /// </summary>
    public class Campus
    {

        /// <summary>
        /// Recupére le parametre id_site dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_site")]
        public int IdCampus { get; set; }

        /// <summary>
        /// Recupére le parametre nom dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomCampus { get; set; }

        /// <summary>
        /// Recupére le parametre nbsalle (nombre de salle) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nbsalle")]
        public int NBSalleCampus { get; set; }

        /// <summary>
        /// Recupére le parametre id_batiment  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_batiment")]
        public int IdBatiment { get; set; }


        /// <summary>
        /// Recupére le parametre NomBatiment  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomBatiment")]
        public string NomBatimen { get; set; }

        /// <summary>
        /// Recupére le parametre NBEtage (nombre d'etage)  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NBEtage")]
        public int NBEtageCampus { get; set; }

        /// <summary>
        /// Recupére le parametre id_etage  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_etage")]
        public int IdEtage { get; set; }

        /// <summary>
        /// Recupére le parametre nomff (nom bat etage)  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nomff")]
        public string NomBatEtage { get; set; }

        /// <summary>
        /// Recupére le parametre num (numéro de l'etage)  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("num")]
        public int NumEtage { get; set; }


        /// <summary>
        /// variavle Post
        /// </summary>

    }
}
