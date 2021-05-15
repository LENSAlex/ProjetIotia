using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Classe Salle
    /// </summary>
    public class Salle
    {
        /// <summary>
        /// Méthode statique permettant de lister les capteurs d'une salle en contactant l'API REST
        /// </summary>
        /// <param name="nomSalle">nom de la salle</param>
        /// <returns>une liste d'objet de CapteurType</returns>
        public static Task<List<CapteurType>> ListCapteurBySalleName(string nomSalle)
        {
            return SalleManager.ListCapteurBySalleName(nomSalle);
        }
    }
}
