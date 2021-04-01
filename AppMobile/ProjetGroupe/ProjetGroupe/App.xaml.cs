﻿using Plugin.SharedTransitions;
using ProjetGroupe.Services;
using ProjetGroupe.Views;
using System;
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
        public App()
        {
            InitializeComponent();
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
