using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClasseE_Covid.Campus
{
    public class OccupationBatiment
    {
        [JsonPropertyName("id_batiment")]
        public int IdBatiment { get; set; }

        [JsonPropertyName("nom")]
        public string NomBatiment { get; set; }

        [JsonPropertyName("taux_occupation")]
        public decimal TauxOccupation { get; set; }

        [JsonPropertyName("capacite_max_batiment")]
        public int CapaciteMaxBat { get; set; }
    }
}
