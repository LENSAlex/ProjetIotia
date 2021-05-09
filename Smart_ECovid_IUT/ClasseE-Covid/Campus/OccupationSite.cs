using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    public class OccupationSite
    {
        [JsonPropertyName("id_site")]
        public int IdSite { get; set; }

        [JsonPropertyName("nom")]
        public string NomSite { get; set; }

        [JsonPropertyName("taux_occupation")]
        public decimal TauxOccupation { get; set; }

        [JsonPropertyName("capacite_max_site")]
        public int CapaciteMaxSite{ get; set;}
    }
}
