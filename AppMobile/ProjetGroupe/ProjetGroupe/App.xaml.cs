using Plugin.SharedTransitions;
using ProjetGroupe.Tools;
using ProjetGroupe.Tools.Services;
using ProjetGroupe.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]
[assembly: ExportFont("NunitoSans-Regular.ttf", Alias = "ThemeFontRegular")]
[assembly: ExportFont("NunitoSans-SemiBold.ttf", Alias = "ThemeFontMedium")]
[assembly: ExportFont("NunitoSans-Bold.ttf", Alias = "ThemeFontBold")]
namespace ProjetGroupe
{
    public partial class App : Application
    {
        void NotificationActionTriggered(object sender, PushAction e) => ShowActionAlert(e);

        void ShowActionAlert(PushAction action)
            => MainThread.BeginInvokeOnMainThread(()
                => MainPage?.DisplayAlert("Alert Covid", $"{action} Cas covid alerté", "OK")
                    .ContinueWith((task) => { if (task.IsFaulted) throw task.Exception; }));
        public App()
        {
            InitializeComponent();
            ServiceContainer.Resolve<IPushDemoNotificationActionService>().ActionTriggered += NotificationActionTriggered;

            var isLoogged = SecureStorage.GetAsync("isLogged").Result;
            if (isLoogged == "1")
            {
            
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
