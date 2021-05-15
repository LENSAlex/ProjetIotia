using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using ProjetGroupe.Models;
using ProjetGroupe.Tools.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetGroupe.Droid.Services
{
    /// <summary>
    /// Classe permettant de lier FireBase à l'appareil
    /// </summary>
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class PushNotificationFirebaseMessagingService : FirebaseMessagingService
    {
        ICovidNotificationActionService _notificationActionService;
        INotificationRegistrationService _notificationRegistrationService;
        IDeviceInstallationService _deviceInstallationService;

        /// <summary>
        /// NotificationActionService
        /// </summary>
        ICovidNotificationActionService NotificationActionService
            => _notificationActionService ??
                (_notificationActionService =
                ServiceContainer.Resolve<ICovidNotificationActionService>());
        /// <summary>
        /// NotificationRegistrationService
        /// </summary>
        INotificationRegistrationService NotificationRegistrationService
            => _notificationRegistrationService ??
                (_notificationRegistrationService =
                ServiceContainer.Resolve<INotificationRegistrationService>());
        /// <summary>
        /// DeviceInstallationService
        /// </summary>
        IDeviceInstallationService DeviceInstallationService
            => _deviceInstallationService ??
                (_deviceInstallationService =
                ServiceContainer.Resolve<IDeviceInstallationService>());
        /// <summary>
        /// Méthode éxecuté lors de la génération d'un nouveau token par l'appareil
        /// </summary>
        /// <param name="token"></param>
        public override void OnNewToken(string token)
        {
            DeviceInstallationService.Token = token;

            NotificationRegistrationService.RefreshRegistrationAsync()
                .ContinueWith((task) => { if (task.IsFaulted) throw task.Exception; });
        }
        /// <summary>
        /// Méthode exécuté lors de la réception d'une notification
        /// </summary>
        /// <param name="message">Informations du message (titre, corps etc)</param>
        public override void OnMessageReceived(RemoteMessage message)
        {
            if (message.Data.TryGetValue("action", out var messageAction))
            {
                NotificationActionService.TriggerAction(messageAction);
            }               
        }
    }
}