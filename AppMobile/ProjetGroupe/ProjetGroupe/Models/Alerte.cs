using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Classe Alerte
    /// </summary>
    public class Alerte
    {
        /// <summary>
        /// Methode statique pouvant être appellé de n'importe ou pour envoyer une notification push
        /// </summary>
        /// <returns>true si envoyée sinon false</returns>
        public static Task<bool> SendNotification()
        {
            return AlerteManager.SendAlert();
        }
    }
}
