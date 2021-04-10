using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class CapteurType
    {
        [JsonProperty("id_device")]
        public int Id { get; set; }
        [JsonProperty("libelle_type")]
        public string LibelleType { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("nom")]
        public string Nom { get; set; }

        public static Task<ObservableCollection<CapteurType>> List()
        {
            return CapteurManager.ListCapteur();
        }
    }
}
