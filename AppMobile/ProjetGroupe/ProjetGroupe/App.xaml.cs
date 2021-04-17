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
    /// <summary>
    /// Classe "Coeur" de l'application
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Actin de notification
        /// </summary>
        /// <param name="sender">L'action de notifier</param>
        /// <param name="e">L'action en question</param>
        void NotificationActionTriggered(object sender, PushAction e) => ShowActionAlert(e);

        /// <summary>
        /// Methode appelée si un utilisateur à l'application ouverte au lieu de lui envoyé une notification sur le téléphone, il affiche juste un popup dans l'application.
        /// </summary>
        /// <param name="action">L'action en question</param>
        async void ShowActionAlert(PushAction action)
        {
            string sendnotif = SecureStorage.GetAsync("SendNotif").Result;
            if(sendnotif == "1")
            {
                SecureStorage.Remove("SendNotif");
                return;
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() => MainPage?.DisplayAlert("Alerte Covid:", $"Un cas covid a été alerté", "OK").ContinueWith((task) => { if (task.IsFaulted) throw task.Exception; }));
            }
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public App()
        {
            InitializeComponent();
            ServiceContainer.Resolve<ICovidNotificationActionService>().ActionTriggered += NotificationActionTriggered;
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
        /// <summary>
        /// Quand l'application démarre
        /// </summary>
        protected override void OnStart()
        {

        }
        /// <summary>
        /// Quand l'application est en veille
        /// </summary>
        protected override void OnSleep()
        {
        }
        /// <summary>
        /// Quand l'application se réouvre
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
