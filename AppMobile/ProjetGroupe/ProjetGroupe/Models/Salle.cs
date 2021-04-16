using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class Salle
    {
        [JsonProperty("id_device")]
        public int Id_device { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }

        [JsonProperty("id_salle")]
        public int Id_salle { get; set; }

        [JsonProperty("id_personne")]
        public int Id_personne { get; set; }  
        public static Salle Load(int Id)
        {
            return new Salle();
        }
        public static Task<List<Salle>> LoadSalleByNom(string nomSalle)
        {
            return SalleManager.LoadSalleByNom(nomSalle);
        }
        public static Task<List<Salle>> ListSalleOfEleve()
        {
            return SalleManager.ListSalleOfEleve();
        }
        public static Task<List<CapteurType>> ListCapteurBySalleId(string nomSalle)
        {
            return SalleManager.ListCapteurBySalleId(nomSalle);
        }
    }
}
