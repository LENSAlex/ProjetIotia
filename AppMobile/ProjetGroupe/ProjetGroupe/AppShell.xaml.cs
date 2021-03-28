using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using ProjetGroupe.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]
namespace ProjetGroupe
{

    public partial class AppShell : Xamarin.Forms.Shell
    {
        public string Email { get => GetMail(); }
        public string UserType  { get => GetUserType(); }
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = this;

            Routing.RegisterRoute(nameof(AccueilPage), typeof(AccueilPage));
            Routing.RegisterRoute(nameof(SmartOfficePage), typeof(SmartOfficePage));
            Routing.RegisterRoute(nameof(SmartBuildingPage), typeof(SmartBuildingPage));
            Routing.RegisterRoute(nameof(eCovidPage), typeof(eCovidPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(CapteursDetailsPage), typeof(CapteursDetailsPage));
            //Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
        }


        private  void OnMenuItemClicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.Remove("isLogged");
            Application.Current.MainPage = new LoginPage();
            //await Shell.Current.GoToAsync("///LoginPage");
        }
        private async void OnSmartOfficePageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/SmartOfficePage");
        }
        private async void OnSmartBuildingPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/SmartBuildingPage");
        }
        private async void OnContactPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/AboutPage");
        }
        private async void OneCovidPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/eCovidPage");
        }
        private async void OnTestPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/CapteursDetailsPage");
        }
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
