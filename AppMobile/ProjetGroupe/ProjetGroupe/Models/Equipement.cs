using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class Equipement
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Libelle")]
        public string Libelle { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("EquipementType")]
        public string EquipementType { get; set; }
        public static Task<ObservableCollection<Equipement>> ListEquipement()
        {
            return EquipementManager.ListEquipement();
        }
    }
}
