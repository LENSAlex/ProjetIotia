using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjetGroupe.Tools;
using ProjetGroupe.Tools.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Provider.Settings;

namespace ProjetGroupe.Droid.Services
{
    /// <summary>
    /// Classe d'installation des notifications sur l'appareil
    /// </summary>
    public class DeviceInstallationService : IDeviceInstallationService
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// NotificationsSupported
        /// </summary>
        public bool NotificationsSupported
            => GoogleApiAvailability.Instance
                .IsGooglePlayServicesAvailable(Application.Context) == ConnectionResult.Success;

        /// <summary>
        /// Régupère l'id de l'appareil
        /// </summary>
        /// <returns></returns>
        public string GetDeviceId()
            => Secure.GetString(Application.Context.ContentResolver, Secure.AndroidId);

        /// <summary>
        /// Récupère l'installation de l'appareil
        /// </summary>
        /// <param name="tags">tags</param>
        /// <returns>DeviceInstallation</returns>
        public DeviceInstallation GetDeviceInstallation(params string[] tags)
        {
            if (!NotificationsSupported)
                throw new Exception(GetPlayServicesError());

            if (string.IsNullOrWhiteSpace(Token))
                throw new Exception("Unable to resolve token for FCM");

            var installation = new DeviceInstallation
            {
                InstallationId = GetDeviceId(),
                Platform = "fcm",
                PushChannel = Token
            };

            installation.Tags.AddRange(tags);

            return installation;
        }
        /// <summary>
        /// Récupère les erreurs GooglePlayService de notification
        /// </summary>
        /// <returns></returns>
        string GetPlayServicesError()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Application.Context);

            if (resultCode != ConnectionResult.Success)
                return GoogleApiAvailability.Instance.IsUserResolvableError(resultCode) ?
                           GoogleApiAvailability.Instance.GetErrorString(resultCode) :
                           "This device is not supported";

            return "An error occurred preventing the use of push notifications";
        }
    }
}