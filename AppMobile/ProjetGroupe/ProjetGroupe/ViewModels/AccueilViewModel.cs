
using Android;
using Android.App;
using Android.Content;
using AndroidX.Core.App;
using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        //public Personne personne { get; set; }
        Context context;
        public Command AlertCovid { get; }
     //   public CasCovid cascovid { get; set; }

        public AccueilViewModel()
        {
            var listView = new ListView();
            AlertCovid = new Command(NotifCovid);
        }
        public void NotifCovid()
        {
            Personne personne = Personne.IsLogged();
            if (personne != null)
            {
                CasCovid cas = new CasCovid()
                {
                    DateDeContamination = DateTime.Now,
                    PersonneId = personne.Id
                };
                CasCovid.SendAlert(cas);
                personne.RappelMail(personne);

                //envoie un mail, une alerte et maybe une notification




             //   string tag = Xamarin.Essentials.SecureStorage.GetAsync("Tag").Result;
                //int token = Xamarin.Essentials.SecureStorage.GetAsync("Token").Result;
                // int test = 5;
               // SendTemplateNotificationAsync(notificationParameters, p_tags);
                // AlertNotifications(context);
              //  SendPushNotification("Test","TestLoris", Convert.ToInt32(tag), "100");
            }
        }

        public void AlertNotifications(Context context)
        {

            var intent = new Intent(context, typeof(AccueilViewModel));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, Android.App.PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(context, Config.NotificationChannelID);

            notificationBuilder.SetContentTitle("Title")
                        .SetSmallIcon(Resource.Drawable.ArrowDownFloat)
                        .SetContentText("Test loris")
                        .SetAutoCancel(true)
                        .SetShowWhen(false)
                        .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(context);

            notificationManager.Notify(0, notificationBuilder.Build());
        }
        public async void SendPushNotification(string p_title, string p_message, int p_assignmentID, string p_tags)
        {
            Dictionary<string, string> notificationParameters = new Dictionary<string, string>();
            Microsoft.Azure.NotificationHubs.NotificationHubClient hub = null;

            hub = Microsoft.Azure.NotificationHubs.NotificationHubClient.CreateClientFromConnectionString(Config.NotificationEndPoint, Config.NotificationHubName);

            notificationParameters.Add("Title", p_title);
            notificationParameters.Add("Message", p_message);
            notificationParameters.Add("AssignmentID", p_assignmentID.ToString());

            await hub.SendTemplateNotificationAsync(notificationParameters, p_tags);
        }
    }
}



