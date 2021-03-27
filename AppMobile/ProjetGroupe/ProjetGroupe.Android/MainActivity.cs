using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Widget;
using Android.Gms.Common;
using WindowsAzure.Messaging.NotificationHubs;
using Firebase;
using Android.Content;
using Syncfusion.XForms.Android.PopupLayout;

namespace ProjetGroupe.Droid
{
    [Activity(Label = "ProjetGroupe", Icon = "@drawable/logoveiut", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
    //    public static string CHANNEL_ID = "Notification";
     //   public static string Hubname = "ProjetCovid";
     //   public static string Endpoint = "Endpoint=sb://projetcovid.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=6u2e8rZYxxWAp3baEl5Hc04Lnsnqpk0Cd+MCbJ/PB94=";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
 
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            SfPopupLayoutRenderer.Init();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FirebaseApp.InitializeApp(this.ApplicationContext);
            NotificationHub.SetListener(new AzureListener());
            //Start the SDK
            NotificationHub.Start(this.Application, Config.NotificationHubName, Config.NotificationEndPoint);
            CreateNotificationChannel();

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var channel = new NotificationChannel(Config.NotificationChannelID, "Notification", NotificationImportance.Default)
            {
                Description = "Test de notification via firebase"
            };
            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}