
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
                AlertNotifications(context);
                //  message.Title = "Test";
                //  message.Body = "Notif loris";
                // AlertNotifications(context, message);
                //personne.RappelMail(personne);
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
    }
}



