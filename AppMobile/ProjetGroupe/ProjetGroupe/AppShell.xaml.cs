using Android.Content;
using ProjetGroupe.Models;
using ProjetGroupe.Tools.Services;
using ProjetGroupe.ViewModels;
using ProjetGroupe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]
namespace ProjetGroupe
{
    /// <summary>
    /// Classe "Gestion du Shell" de l'application
    /// </summary>
    public partial class AppShell : Shell, INotifyPropertyChanged
    {
        /// <summary>
        /// Méthode de changement d'une propriété sur le front
        /// </summary>
        /// <param name="propertyName">nom de la propriété</param>
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
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
        public string UserType { get => GetUserType(); }
        /// <summary>
        /// var imgpath
        /// </summary>
        public string imgpath;
        /// <summary>
        /// URI de l'image du profil
        /// </summary>
        public string ImagePath
        {
            get
            {
                return imgpath;
            }
            set
            {
                imgpath = value;
                RaisepropertyChanged("ImagePath");
            }
        }
        public string isvisible;
        /// <summary>
        /// URI de l'image du profil
        /// </summary>
        public string isVisible
        {
            get
            {
                return isvisible;
            }
            set
            {
                isvisible = value;
                RaisepropertyChanged("isVisible");
            }
        }
        /// <summary>
        /// Command d'excécution du click sur l'image
        /// </summary>
        public Command ImgClicked { get; }
        /// <summary>
        /// Command d'exécution du click sur la croix
        /// </summary>
        public Command DelPhoto { get; }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public AppShell()
        {
            Device.BeginInvokeOnMainThread(() => GetImagePath());
            ImgClicked = new Command(SetImgAsync);
            DelPhoto = new Command(DeleteImage);
            InitializeComponent();
            this.BindingContext = this;
            _notificationRegistrationService = ServiceContainer.Resolve<INotificationRegistrationService>();
            //Toutes nos pages enregistrées dans le shell
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
        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            //Logout on supprime toutes les variables
            SecureStorage.Remove("CapteurId");
            SecureStorage.Remove("isLogged");
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
        /// <summary>
        /// Méthode qui change l'URI de l'image de profil par la nouvelle 
        /// </summary>
        public void GetImagePath()
        {
            if(ImagePath != "")
            {
                ImagePath = SecureStorage.GetAsync("PathProfil").Result;
            }
            else
            {
                ImagePath = "";
            }
        }
        /// <summary>
        /// Quand on click pour mettre l'image (click sur photo)
        /// </summary>
        /// <param name="obj">Le click</param>
        private async void SetImgAsync(object obj)
        {
            //On ouvre la galerie pour choisir la photo
            DependencyService.Get<ISave>().OpenGallery();
            isVisible = "true";
        }
        /// <summary>
        /// Au click de la croix pour supprimer la photo
        /// </summary>
        /// <param name="obj">le Click</param>
        private async void DeleteImage(object obj)
        {
            if(ImagePath != "")
            {
                var result = await DisplayAlert("Attention!", "Voulez vous vraiment supprimer votre photo de profil", "Oui", "Non");
                if (result == true)
                {
                    DependencyService.Get<ISave>().DisplayAlert("Supprimée");
                    SecureStorage.Remove("PathProfil");
                    ImagePath = "";
                    isVisible = "false";
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
