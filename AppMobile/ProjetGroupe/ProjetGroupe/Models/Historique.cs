using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class Historique
    {
        [JsonProperty("id_device")]
        public int Id_device { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("unite")]
        public string Unite { get; set; }
        [JsonProperty("valeur")]
        public string Valeur { get; set; }
        public DateTime date_historique { get; set; }
        public int Id_Historique { get; set; }

        public static Task<List<Historique>> ListHistorique()
        {
            return HistoriqueManager.ListHistorique();
        }
        public static Task<List<Historique>> ListValeurLast(int CapteurId)
        {
            return HistoriqueManager.ListValeurLast(CapteurId);
        }
        public static Task<List<Historique>> ListValeurMoyenne(int CapteurId)
        {
            return HistoriqueManager.ListValeurMoyenne(CapteurId);
        }
        //TODO Generation PDF donnees capteur + Affichage données capteur + Erreur AppShell sur le s8
    }

}
