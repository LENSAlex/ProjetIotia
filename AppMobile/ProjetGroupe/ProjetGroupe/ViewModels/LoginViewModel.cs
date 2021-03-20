using ProjetGroupe.Models;
using ProjetGroupe.Tools;
using ProjetGroupe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            LoginCommand = new Command(OnLoginClicked);
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
            if (!String.IsNullOrEmpty(identifiant) && !String.IsNullOrEmpty(password))
            {
                Personne utilisateur = Personne.Search(identifiant, MHash.HashString(password));

                if (utilisateur != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(AccueilPage)}");
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
                }
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            }
        }
    }
}
