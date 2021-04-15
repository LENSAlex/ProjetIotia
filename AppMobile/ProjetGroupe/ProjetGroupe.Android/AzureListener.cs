using Android.App;
using Android.Content;
using AndroidX.Core.App;
using WindowsAzure.Messaging.NotificationHubs;

namespace ProjetGroupe.Droid
{
    public class AzureListener : Java.Lang.Object, WindowsAzure.Messaging.NotificationHubs.INotificationListener
    {
        public void OnPushNotificationReceived(Context context, WindowsAzure.Messaging.NotificationHubs.INotificationMessage message)
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