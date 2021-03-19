using ProjetGroupe.Views;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SaveCommand { get; }
        public static CookieContainer CookieContainer = new CookieContainer();

        private string identifiant;
        private string password;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked, ValidateSave);
        }

        private bool ValidateSave(object arg)
        {
            return !String.IsNullOrWhiteSpace(identifiant)
                && !String.IsNullOrWhiteSpace(password);
        }

        public string Identifiant
        {
            get => identifiant;
            set => SetProperty(ref identifiant, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async void OnLoginClicked(object obj)
        {
            var handler = new HttpClientHandler { CookieContainer = CookieContainer };
            var httpClient = new HttpClient(handler);
            CookieContainer = handler.CookieContainer;

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AccueilPage)}");    
        }
    }
}
