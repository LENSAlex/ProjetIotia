using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.IOTDevise
{
    /// <summary>
    /// IOTDevise et une class qui est utiliser pour recupére les valuer des requette Get sur les IOT Devise
    /// </summary>
    public class IOTDevise
    {
        /// <summary>
        /// Recupére le parametre id_box  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_box")]
        public int Id_box { get; set; }

        /// <summary>
        /// Recupére le parametre libelle (Nom Box) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        /// <summary>
        /// Recupére le parametre adr_ip  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("adr_ip")]
        public string AdrIpBox { get; set; }

        /// <summary>
        /// Recupére le parametre description  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("description")]
        public string DescriptionBox { get; set; }

        /// <summary>
        /// Recupére le parametre nom (Nom Batiment Box) dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("nom")]
        public string NomBatimentBox { get; set; }

        /// <summary>
        /// Recupére le parametre id_etage  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("id_etage")]
        public int IdEtageBox { get; set; }

        /// <summary>
        /// Recupére le parametre NomSalle dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NomSalle")]
        public string IdSalleBox { get; set; }

        /// <summary>
        /// Recupére le parametre PanneauSolaire  dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("PanneauSolaire")]
        public int NbPanneauSolaire { get; set; }

        /// <summary>
        /// Recupére le parametre NbBouton dans sur la requette Get
        /// JsonPropertyName est utiliser pour sibler la variable de API
        /// </summary>
        [JsonPropertyName("NbBouton")]
        public int NbBouton { get; set; }
    }
}
