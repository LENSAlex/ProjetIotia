using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Classe Historique des valeurs des capteurs
    /// </summary>
    public class Historique
    {
        /// <summary>
        /// Id du capteur
        /// </summary>
        [JsonProperty("id_device")]
        public int Id_device { get; set; }
        /// <summary>
        /// Libelle du capteur
        /// </summary>
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        /// <summary>
        /// Unité de ses mesures
        /// </summary>
        [JsonProperty("unite")]
        public string Unite { get; set; }
        /// <summary>
        /// Valeur enregistrée
        /// </summary>
        [JsonProperty("valeur")]
        public string Valeur { get; set; }
        /// <summary>
        /// Moyenne des valeurs enregistrées
        /// </summary>
        [JsonProperty("Moyenne")]
        public string Moyenne { get; set; }
        /// <summary>
        /// LibelleType des unités
        /// </summary>
        [JsonProperty("libelle_type")]
        public string LibelleType { get; set; }
        /// <summary>
        /// Méthoed statique contactant l'API REST 
        /// </summary>
        /// <returns>une liste d'historique</returns>
        public static Task<List<Historique>> ListHistorique()
        {
            return HistoriqueManager.ListHistorique();
        }
        /// <summary>
        /// Méthoed statique contactant l'API REST prenant un Id de capteur en paramètre pour cibler un capteur 
        /// </summary>
        /// <param name="CapteurId">Id du capteur</param>
        /// <returns>liste d'historique</returns>
        public static Task<List<Historique>> ListValeurLast(int CapteurId)
        {
            return HistoriqueManager.ListValeurLast(CapteurId);
        }
        /// <summary>
        /// Méthoed statique contactant l'API REST prenant un Id de capteur en paramètre pour cibler la moyenne des valeurs d'un capteur 
        /// </summary>
        /// <param name="CapteurId">Id du capteur</param>
        /// <returns>liste d'historique</returns>
        public static Task<List<Historique>> ListValeurMoyenne(int CapteurId)
        {
            return HistoriqueManager.ListValeurMoyenne(CapteurId);
        }
        /// <summary>
        /// Méthoed statique contactant l'API REST prenant un Id de capteur en paramètre pour cibler un capteur précis
        /// </summary>
        /// <param name="CapteurId">Id du capteur</param>
        /// <returns>liste d'historique</returns>
        public static Task<List<Historique>> Load(int CapteurId)
        {
            return HistoriqueManager.Load(CapteurId);
        }
    }
}
