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
        [JsonProperty("id_equipement")]
        public int Id { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("EquipementType")]
        public string EquipementType { get; set; }
        public static Task<ObservableCollection<Equipement>> ListEquipement()
        {
            return EquipementManager.ListEquipement();
        }
    }
}
