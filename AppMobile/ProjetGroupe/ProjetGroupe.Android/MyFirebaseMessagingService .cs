using Android.App;
using Android.Content;
using Android.Content;
using WindowsAzure.Messaging.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.Core.App;

namespace ProjetGroupe.Droid
{
    public class MyFirebaseMessagingService: Java.Lang.Object, INotificationListener
    {
        public void OnPushNotificationReceived(Context context, INotificationMessage message)
        {
            var intent = new Intent(context, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, Android.App.PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(context, Config.NotificationChannelID);

            notificationBuilder.SetContentTitle(message.Title)
                        .SetSmallIcon(Resource.Drawable.icon_about)
                        .SetContentText(message.Body)
                        .SetAutoCancel(true)
                        .SetShowWhen(false)
                        .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(context);

            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}