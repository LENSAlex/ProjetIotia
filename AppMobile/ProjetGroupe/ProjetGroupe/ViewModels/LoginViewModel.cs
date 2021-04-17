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
    /// <summary>
    /// View de la page login
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Commande lors du clique sur le bouton connexion
        /// </summary>
        public Command LoginCommand { get; }

        private string identifiant;
        /// <summary>
        /// Récupération de l'identifiant saisie par l'utilisateur
        /// </summary>
        public string Identifiant
        {
            get => identifiant;
            set => SetProperty(ref identifiant, value);
        }
        private string password;
        /// <summary>
        /// Récupération du mdp saisie par l'utilisateur
        /// </summary>
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        /// <summary>
        /// Méthode exécuté lors du click sur le bouton connexion
        /// </summary>
        /// <param name="obj">Le click</param>
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
        /// <summary>
        /// Méthode permettant d'enregistrer un appareil au channel de notification FireBase
        /// </summary>
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

