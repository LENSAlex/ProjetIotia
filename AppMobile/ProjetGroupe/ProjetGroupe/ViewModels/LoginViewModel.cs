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
        public string Erreur { get; set; }

        private string identifiant;
        public string Identifiant
        {
            get => identifiant;
            set => SetProperty(ref identifiant, value);
        }
        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (!String.IsNullOrEmpty(identifiant) && !String.IsNullOrEmpty(password))
            {
                Personne utilisateur = Personne.Search(identifiant, MHash.HashString(password));

                if (utilisateur != null)
                {
                    await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                    await Xamarin.Essentials.SecureStorage.SetAsync("Id", utilisateur.Id.ToString());
                    RegisterDeviceForPushNotifications();
                    Xamarin.Forms.Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"{nameof(AccueilPage)}");
                }
                else
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Erreur:", "Informations incorrectes", "Ok");
                }
            }
        }
        public static void RegisterDeviceForPushNotifications()
        {
            IRegisterNotifications reg = null;
            List<string> tagList = new List<string>();
            string token = "";
            string tags = "";

            tags = Xamarin.Essentials.SecureStorage.GetAsync("Tag").Result;

            if (tags != null)
            {
                token = Xamarin.Essentials.SecureStorage.GetAsync("HubToken").Result;              
                tagList.Add(tags);
                tagList.Add("DCW");         
                reg = Xamarin.Forms.DependencyService.Get<IRegisterNotifications>();
                reg.RegisterDevice(token, tagList);
            }
        }
    }
}

