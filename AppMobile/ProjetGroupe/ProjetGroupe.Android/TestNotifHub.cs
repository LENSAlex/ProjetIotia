using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetGroupe.Droid
{
    public class TestNotifHub
    {
        public string Token { get; set; }
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