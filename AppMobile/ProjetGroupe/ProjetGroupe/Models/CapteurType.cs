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
    /// Classe CapteurType
    /// </summary>
    public class CapteurType
    {
        /// <summary>
        /// Id du capteur
        /// </summary>
        [JsonProperty("id_device")]
        public int Id { get; set; }
        /// <summary>
        /// Description du capteur
        /// </summary>
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        /// <summary>
        /// Nom du bâtiment ou il se trouve
        /// </summary>
        [JsonProperty("nom")]
        public string Nom { get; set; }
        /// <summary>
        /// Id de la salle ou se trouve
        /// </summary>
        [JsonProperty("id_salle")]
        public int SalleId { get; set; }
        /// <summary>
        /// Méthode statique permettant de listé les capteurs
        /// </summary>
        /// <returns>Une ObservableCollection de CapteurType</returns>
        public static Task<ObservableCollection<CapteurType>> List()
        {
            return CapteurManager.ListCapteur();
        }
    }
}
