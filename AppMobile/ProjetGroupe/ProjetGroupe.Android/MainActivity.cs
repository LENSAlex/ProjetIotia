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
using Firebase.Iid;
using Java.Lang;
using ProjetGroupe.Tools.Services;
using ProjetGroupe.Droid.Services;
using Xamarin.Forms;

namespace ProjetGroupe.Droid
{
    /// <summary>
    /// Classe principale de l'application sous Android
    /// </summary>
    [Activity(Label = "E-Covid !", Icon = "@drawable/logoveiut", Theme = "@style/MainTheme", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, Android.Gms.Tasks.IOnSuccessListener
    {
        /// <summary>
        /// Méthode appelée la création de l'application
        /// </summary>
        /// <param name="savedInstanceState">Les pages</param>
        [System.Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Bootstrap.Begin(() => new DeviceInstallationService());
            if (DeviceInstallationService.NotificationsSupported)
            {
                FirebaseInstanceId.GetInstance(FirebaseApp.Instance)
                    .GetInstanceId()
                    .AddOnSuccessListener(this);
            }
            Forms.SetFlags("SwipeView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());

            ProcessNotificationActions(Intent);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FirebaseApp.InitializeApp(this.ApplicationContext);
            var fb = FirebaseApp.InitializeApp(this.ApplicationContext);
            NotificationHub.Start(this.Application, Config.NotificationHubName, Config.NotificationEndPoint);
        }
        /// <summary>
        /// Récupère les permissions données à l'application
        /// </summary>
        /// <param name="requestCode">requestCode</param>
        /// <param name="permissions">permissions</param>
        /// <param name="grantResults">grantResults</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        /// <summary>
        /// Méthode appelée lors du succès de l'installation de l'application
        /// </summary>
        /// <param name="result"></param>
        public void OnSuccess(Java.Lang.Object result)
            => DeviceInstallationService.Token =
                result.Class.GetMethod("getToken").Invoke(result).ToString();

        ICovidNotificationActionService _notificationActionService;
        IDeviceInstallationService _deviceInstallationService;
        /// <summary>
        /// NotificationActionService
        /// </summary>
        ICovidNotificationActionService NotificationActionService
            => _notificationActionService ??
                (_notificationActionService =
                ServiceContainer.Resolve<ICovidNotificationActionService>());
        /// <summary>
        /// DeviceInstallationService
        /// </summary>
        IDeviceInstallationService DeviceInstallationService
            => _deviceInstallationService ??
                (_deviceInstallationService =
                ServiceContainer.Resolve<IDeviceInstallationService>());
        /// <summary>
        /// Méthode exécuté dans le OnCreate
        /// </summary>
        /// <param name="intent">Les Intents</param>
        void ProcessNotificationActions(Intent intent)
        {
            try
            {
                if (intent?.HasExtra("action") == true)
                {
                    var action = intent.GetStringExtra("action");

                    if (!string.IsNullOrEmpty(action))
                        NotificationActionService.TriggerAction(action);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Méthode appelée quand il y a une nouvelle Intent 
        /// </summary>
        /// <param name="intent"></param>
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            ProcessNotificationActions(intent);

            LoadApplication(new App());
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FirebaseApp.InitializeApp(this.ApplicationContext);
            NotificationHub.Start(this.Application, Config.NotificationHubName, Config.NotificationEndPoint);
        }
    }
}