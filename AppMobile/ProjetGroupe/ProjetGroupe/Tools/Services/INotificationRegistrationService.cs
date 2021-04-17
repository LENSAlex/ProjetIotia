using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Interface pour l'enregistrement du smartphone au channel de notification
    /// </summary>
    public interface INotificationRegistrationService
    {
        /// <summary>
        /// Unregister
        /// </summary>
        /// <returns>task</returns>
        Task DeregisterDeviceAsync();
        /// <summary>
        /// Enregistrement de l'appareil
        /// </summary>
        /// <param name="tags">tags</param>
        /// <returns>task</returns>
        Task RegisterDeviceAsync(params string[] tags);
        /// <summary>
        /// Vérifie les enregistrements des appareils
        /// </summary>
        /// <returns>task</returns>
        Task RefreshRegistrationAsync();
    }
}
