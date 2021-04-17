using ProjetGroupe.Models;
using ProjetGroupe.Tools.Services;
using ProjetGroupe.ViewModels;
using ProjetGroupe.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]
namespace ProjetGroupe
{
    /// <summary>
    /// Classe "Gestion du Shell" de l'application
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// INotificationRegistrationService
        /// </summary>
        readonly INotificationRegistrationService _notificationRegistrationService;
        /// <summary>
        /// Affichage du mail de la personne dans le FlyoutHeader
        /// </summary>
        public string Email { get => GetMail(); }
        /// <summary>
        /// Affichage du type de la personne dans le FlyoutHeader
        /// </summary>
        public string UserType  { get => GetUserType(); }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = this;

            _notificationRegistrationService = ServiceContainer.Resolve<INotificationRegistrationService>();

            Routing.RegisterRoute(nameof(AccueilPage), typeof(AccueilPage));
            Routing.RegisterRoute(nameof(SmartOfficePage), typeof(SmartOfficePage));
            Routing.RegisterRoute(nameof(SmartBuildingPage), typeof(SmartBuildingPage));
            Routing.RegisterRoute(nameof(eCovidPage), typeof(eCovidPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(CapteursDetailsPage), typeof(CapteursDetailsPage));

            Device.BeginInvokeOnMainThread(() => _notificationRegistrationService.RegisterDeviceAsync());    
 
        }

        /// <summary>
        /// Click sur le Logout
        /// </summary>
        /// <param name="sender">Le click</param>
        /// <param name="e">L'action du click</param>
        private  void OnMenuItemClicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.Remove("CapteurId");
            Xamarin.Essentials.SecureStorage.Remove("isLogged");
            Application.Current.MainPage = new LoginPage();
        }
        /// <summary>
        /// Click sur le SmartOfficePage
        /// </summary>
        /// <param name="sender">Le click</param>
        /// <param name="e">L'action du click</param>
        private async void OnSmartOfficePageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/SmartOfficePage");
        }
        /// <summary>
        /// Click sur le SmartBuildingPage
        /// </summary>
        /// <param name="sender">Le click</param>
        /// <param name="e">L'action du click</param>
        private async void OnSmartBuildingPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/SmartBuildingPage");
        }
        /// <summary>
        /// Click sur le AboutPage
        /// </summary>
        /// <param name="sender">Le click</param>
        /// <param name="e">L'action du click</param>
        private async void OnContactPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/AboutPage");
        }
        /// <summary>
        /// Click sur le eCovidPage
        /// </summary>
        /// <param name="sender">Le click</param>
        /// <param name="e">L'action du click</param>
        private async void OneCovidPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/eCovidPage");
        }
        /// <summary>
        /// Récupération du mail de la personne
        /// </summary>
        /// <returns>Le mail si existe sinon null</returns>
        public string GetMail()
        {
            var personne = Personne.IsLogged();
            if (personne != null)
            {
                string email = personne?.Email;
                return email;
            }
            else
            {
                return "null";
            }
        }
        /// <summary>
        /// Récupération du type de la personne
        /// </summary>
        /// <returns>Le Type de la personne si existe sinon null</returns>
        public string GetUserType()
        {
            var personne = Personne.IsLogged();
            if (personne != null)
            {
                PersonneType type = (PersonneType)personne?.PersonneType;
                return type.ToString();
            }
            else
            {
                return "null";
            }
        }

    }
}
