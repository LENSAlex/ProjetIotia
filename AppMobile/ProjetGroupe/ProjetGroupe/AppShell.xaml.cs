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
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AccueilPage), typeof(AccueilPage));
            Routing.RegisterRoute(nameof(SmartOfficePage), typeof(SmartOfficePage));
            Routing.RegisterRoute(nameof(SmartBuildingPage), typeof(SmartBuildingPage));
            Routing.RegisterRoute(nameof(eCovidPage), typeof(eCovidPage));
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
        private async void OneCovidPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("/eCovidPage");
        }
    }
}
