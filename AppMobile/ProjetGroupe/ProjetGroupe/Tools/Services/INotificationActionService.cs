using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Interface pour les notifications
    /// </summary>
    public interface INotificationActionService
    {
        /// <summary>
        /// Fonction pour l'évènement d'envoie de la notification sur le smartphone
        /// </summary>
        /// <param name="action"></param>
        void TriggerAction(string action);
    }
}
