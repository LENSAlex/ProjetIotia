using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Capteur
{
    /// <summary>
    /// Co2 et une class qui est utiliser pour recupére les valuer des requette Get du Co2
    /// </summary>
    public class Co2
    {
        /// <summary>
        /// Recupére le parametre libelle_type (Nom Co2) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle_type")]
        public string NomCo2 { get; set; }

        /// <summary>
        /// Recupére le parametre libelle (Nom Box) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        /// <summary>
        /// Recupére le parametre valeur  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("valeur")]
        public int ValeurCo2 { get; set; }

        /// <summary>
        /// Recupére le parametre Nom Salle dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomSalle")]
        public string NomSalle { get; set; }

        /// <summary>
        /// Recupére le parametre Nom Etage dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomEtage")]
        public string NomEtage { get; set; }

        /// <summary>
        /// Recupére le parametre Nom Batiment dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomBatiment")]
        public string NomBatiment { get; set; }

        /// <summary>
        /// Recupére le parametre Nom Site dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomSite")]
        public string NomSite { get; set; }

        /// <summary>
        /// Recupére le parametre date_historique dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("date_historique")]
        public DateTime Date { get; set; }
    }
}
