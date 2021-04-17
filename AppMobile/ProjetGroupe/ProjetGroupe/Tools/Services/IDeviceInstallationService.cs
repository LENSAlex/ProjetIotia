using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Interface pour les notifications
    /// </summary>
    public interface IDeviceInstallationService
    {
        /// <summary>
        /// Token
        /// </summary>
        string Token { get; set; }
        /// <summary>
        /// NotificationsSupported
        /// </summary>
        bool NotificationsSupported { get; }
        /// <summary>
        /// Id du smartphone
        /// </summary>
        /// <returns></returns>
        string GetDeviceId();
        /// <summary>
        /// Informations appareil
        /// </summary>
        /// <param name="tags">tags</param>
        /// <returns>DeviceInstallation</returns>
        DeviceInstallation GetDeviceInstallation(params string[] tags);
    }
}
