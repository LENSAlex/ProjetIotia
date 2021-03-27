using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class AndroidFireBaseMessagingService : Firebase.Messaging.FirebaseMessagingService
    {
        public override void OnNewToken(string token)
        {
            Xamarin.Essentials.SecureStorage.SetAsync("HubToken", token);
            Xamarin.Essentials.SecureStorage.Remove("Tag");
            //  UtilityFunctions.SetStoredValue(UtilityFunctions.AZURE_NOTIFICATIONS_REGISTRATION_TOKEN, token);
            //  UtilityFunctions.DeleteStoredValue(UtilityFunctions.AZURE_NOTIFICATIONS_REGISTRATION_TAGS);
        }

        public override void OnMessageReceived(Firebase.Messaging.RemoteMessage message)
        {
            if (message.GetNotification() != null)
            {
                SendNotification(message.GetNotification().Body);
            }
            else
            {
                SendNotification(message.Data.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
            }
        }

        private void SendNotification(string p_message)
        {
            SendNotification(new Dictionary<string, string> { { "Message", p_message } });
        }

        private async void SendNotification(Dictionary<string, string> p_values)
        {
            try
            {
                await Task.Run(() =>
                {
                    Intent intent = null;
                    PendingIntent pendingIntent = null;

                    intent = new Intent(this, typeof(MainActivity));
                    intent.AddFlags(ActivityFlags.ClearTop);

                    if (p_values.ContainsKey("AssignmentID"))
                    {
                        intent.PutExtra("AssignmentID", p_values["AssignmentID"]);
                    }

                    pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

                    var notificationBuilder = new NotificationCompat.Builder(this, Config.NotificationChannelID);

                    notificationBuilder.SetContentTitle("Message Title");
                    notificationBuilder.SetSmallIcon(Resource.Drawable.ic_launcher);

                    if (p_values.ContainsKey("Title"))
                    {
                        notificationBuilder.SetContentTitle(p_values["Title"]);
                    }

                    if (p_values.ContainsKey("Message"))
                    {
                        notificationBuilder.SetContentText(p_values["Message"]);
                    }

                    notificationBuilder.SetAutoCancel(true);
                    notificationBuilder.SetShowWhen(false);
                    notificationBuilder.SetContentIntent(pendingIntent);

                    var notificationManager = NotificationManager.FromContext(this);

                    notificationManager.Notify(0, notificationBuilder.Build());
                });
            }
            catch (Exception ex)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("Erreur", ex.ToString());
                await Xamarin.Essentials.SecureStorage.SetAsync("ErreurTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                //  UtilityFunctions.SetStoredValue(UtilityFunctions.LAST_EXCEPTION, ex.ToString());
                //  UtilityFunctions.SetStoredValue(UtilityFunctions.LAST_EXCEPTION_DATE, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
            }
        }

        public static async Task<string> GetRegistrationIdAsync(string p_handle, Microsoft.Azure.NotificationHubs.NotificationHubClient p_hub)
        {
            Microsoft.Azure.NotificationHubs.CollectionQueryResult<Microsoft.Azure.NotificationHubs.RegistrationDescription> registrations = null;
            string psnHandle = "";
            string newRegistrationId = null;

            if (string.IsNullOrEmpty(p_handle))
            {
                throw new ArgumentNullException("handle could not be empty or null");
            }

            psnHandle = p_handle.ToUpper();

            registrations = await p_hub.GetRegistrationsByChannelAsync(psnHandle, 100);

            foreach (Microsoft.Azure.NotificationHubs.RegistrationDescription registration in registrations)
            {
                if (newRegistrationId == null)
                {
                    newRegistrationId = registration.RegistrationId;
                }
                else
                {
                    await p_hub.DeleteRegistrationAsync(registration);
                }
            }

            if (newRegistrationId == null)
            {
                newRegistrationId = await p_hub.CreateRegistrationIdAsync();
            }

            return newRegistrationId;
        }

        public static async void SendRegistrationToServer(string p_token, List<string> p_tags)
        {
            Microsoft.Azure.NotificationHubs.NotificationHubClient hub;
            Microsoft.Azure.NotificationHubs.FcmTemplateRegistrationDescription registration;
            Microsoft.Azure.NotificationHubs.FcmTemplateRegistrationDescription registrationResult;
            string messageTemplate = "";
            string tags = "";

            foreach (var item in p_tags)
            {
                if (tags != "")
                {
                    tags += ",";
                }

                tags += item;
            }

            hub = Microsoft.Azure.NotificationHubs.NotificationHubClient.CreateClientFromConnectionString(Config.NotificationEndPoint, Config.NotificationHubName);

            messageTemplate = "{\"data\":{\"Title\":\"$(title)\",\"Message\":\"$(message)\", \"AssignmentID\":\"$(assignmentID)\"}}";

            registration = new Microsoft.Azure.NotificationHubs.FcmTemplateRegistrationDescription(p_token, messageTemplate);

            try
            {
                registration.RegistrationId = await GetRegistrationIdAsync(p_token, hub);
                registration.Tags = new HashSet<string>(p_tags);

                registrationResult = await hub.CreateOrUpdateRegistrationAsync(registration);
                await Xamarin.Essentials.SecureStorage.SetAsync("Tag", tags);
                await Xamarin.Essentials.SecureStorage.SetAsync("RegId", registration.PnsHandle);
                //  Xamarin.Essentials.SecureStorage.GetAsync("HubToken").Result;
                // string token = (string)FirebaseInstanceId.GetInstance(fb);

                //UtilityFunctions.SetStoredValue(UtilityFunctions.AZURE_NOTIFICATIONS_REGISTRATION_TAGS, tags);
                // UtilityFunctions.SetStoredValue(UtilityFunctions.AZURE_NOTIFICATIONS_REGISTRATION_REGID, registration.PnsHandle);
            }
            catch (Exception ex)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("Erreur", ex.ToString());
                await Xamarin.Essentials.SecureStorage.SetAsync("ErreurTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                //UtilityFunctions.SetStoredValue(UtilityFunctions.LAST_EXCEPTION, ex.ToString());
                // UtilityFunctions.SetStoredValue(UtilityFunctions.LAST_EXCEPTION_DATE, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
            }
        }

        public static async void UnRegisterDevice()
        {
            //TODO: Implment later
        }
    }
}