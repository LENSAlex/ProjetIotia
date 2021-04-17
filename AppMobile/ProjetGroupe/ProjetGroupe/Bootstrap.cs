using ProjetGroupe.Tools.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe
{
    /// <summary>
    /// Classe de lancement du système de notification sur l'appareil
    /// </summary>
    public static class Bootstrap
    {
        /// <summary>
        /// Lacement
        /// </summary>
        /// <param name="deviceInstallationService">appareil</param>
        public static void Begin(Func<IDeviceInstallationService> deviceInstallationService)
        {
            ServiceContainer.Register(deviceInstallationService);

            ServiceContainer.Register<ICovidNotificationActionService>(() => new CovidNotificationActionService());

            ServiceContainer.Register<INotificationRegistrationService>(() => new NotificationRegistrationService(Configuration.BackendServiceEndpoint));
        }
    }
}
