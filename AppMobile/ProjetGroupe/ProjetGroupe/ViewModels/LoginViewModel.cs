using Android;
using Android.App;
using Android.Content;
using ProjetGroupe.Models;
using ProjetGroupe.Tools;
using ProjetGroupe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SaveCommand { get; }
        // public string userPref = "userPref";
        // public ISharedPreferences session = GetSharedPreferences(userPref, FileCreationMode.Private);
        public static CookieContainer CookieContainer = new CookieContainer();

        private string identifiant;
        private string password;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        public string Erreur { get; set; }

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

            // var handler = new HttpClientHandler { CookieContainer = CookieContainer };
            // var httpClient = new HttpClient(handler);
            //  CookieContainer = handler.CookieContainer;
            //  ISharedPreferencesEditor session = session.;

            if (!String.IsNullOrEmpty(identifiant) && !String.IsNullOrEmpty(password))
            {
                Personne utilisateur = Personne.Search(identifiant, MHash.HashString(password));

                if (utilisateur != null)
                {
                    await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                    await Xamarin.Essentials.SecureStorage.SetAsync("Id", utilisateur.Id.ToString());
                    Xamarin.Forms.Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"{nameof(AccueilPage)}");
                }
                else
                {
                    //Page page = new Page();
                    //await page.DisplayAlert("Alert", "You have been alerted", "OK");
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Erreur:", "Informations incorrectes", "Ok");
                }
            }
            //    else
            //    {
            //        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            //    }
            //}
            //else
            //{
            //    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            //}
        }
    }
}

