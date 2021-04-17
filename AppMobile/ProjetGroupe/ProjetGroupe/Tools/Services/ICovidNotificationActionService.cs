using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Infertace pour l'évènement d'envoie d'une notification
    /// </summary>
    public interface ICovidNotificationActionService : INotificationActionService
    {
        /// <summary>
        /// Nom de l'évènement
        /// </summary>
        event EventHandler<PushAction> ActionTriggered;
    }
}
