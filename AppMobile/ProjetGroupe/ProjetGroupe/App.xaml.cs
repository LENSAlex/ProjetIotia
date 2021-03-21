using ProjetGroupe.Services;
using ProjetGroupe.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            //MainPage = new AppShell();
            var isLoogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
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
