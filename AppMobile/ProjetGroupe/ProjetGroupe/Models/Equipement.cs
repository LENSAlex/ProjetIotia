using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Classe Equipement
    /// </summary>
    public class Equipement
    {
        /// <summary>
        /// Id de l'équipement
        /// </summary>
        [JsonProperty("id_equipement")]
        public int Id { get; set; }
        /// <summary>
        /// Libelle de l'équipement
        /// </summary>
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        /// <summary>
        /// Description de celui-ci
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Type d'équipement
        /// </summary>
        [JsonProperty("EquipementType")]
        public string EquipementType { get; set; }
        /// <summary>
        /// Methode statique qui contacte l'API REST
        /// </summary>
        /// <returns>une ObservableCollection d'équipement</returns>
        public static Task<ObservableCollection<Equipement>> ListEquipement()
        {
            return EquipementManager.ListEquipement();
        }
    }
}
