using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.IOTDevise
{
    public class IOTDevise
    {
        /// <summary>
        /// liste Box
        /// </summary>
        
        [JsonPropertyName("id_box")]
        public int Id_box { get; set; }

        [JsonPropertyName("libelle")]
        public string NomBox { get; set; }

        [JsonPropertyName("adr_ip")]
        public string AdrIpBox { get; set; }

        [JsonPropertyName("description")]
        public string DescriptionBox { get; set; }

        [JsonPropertyName("nom")]
        public string NomBatimentBox { get; set; }

        [JsonPropertyName("id_etage")]
        public int IdEtageBox { get; set; }

        [JsonPropertyName("NomSalle")]
        public string IdSalleBox { get; set; }

        [JsonPropertyName("PanneauSolaire")]
        public int NbPanneauSolaire { get; set; }

        [JsonPropertyName("NbBouton")]
        public int NbBouton { get; set; }
    }
}
