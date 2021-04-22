using ProjetGroupe.Models;
using ProjetGroupe.Tools;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    /// <summary>
    /// Back du front de la page de login
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        /// <summary>
        /// TextBox Password entrée validée
        /// </summary>
        /// <param name="sender">L'utilisateur</param>
        /// <param name="e">L'action</param>
        private async void Entry_Completed(object sender, EventArgs e)
        {
            ProgressBar.IsVisible = true;
            var entry = (Entry)sender;
            if((!string.IsNullOrEmpty(Identifiant.Text) && !string.IsNullOrEmpty(entry.Text)))
            {
                Personne utilisateur = Personne.Search(Identifiant.Text, MHash.HashString(entry.Text));

                if (utilisateur != null)
                {
                    SecureStorage.SetAsync("isLogged", "1");
                    SecureStorage.SetAsync("Id", utilisateur.Id.ToString());
                    await ProgressBar.ProgressTo(1, 500, Easing.Linear);
                    Application.Current.MainPage = new AppShell();
                    Shell.Current.GoToAsync($"{nameof(AccueilPage)}");
                }
                else
                {
                     Application.Current.MainPage.DisplayAlert("Erreur:", "Informations incorrectes", "Ok");
                }
            }
        }
        /// <summary>
        /// TextBox Identifiant entrée validée
        /// </summary>
        /// <param name="sender">L'utilisateur</param>
        /// <param name="e">L'action</param>
        private void Entry_Completed_1(object sender, EventArgs e)
        {
            var entry = (Entry)sender;
            if(entry.Text != "")
            {
                FramePsw.BackgroundColor = Color.Transparent;
                Password.Placeholder = "Mot de passe";
                Password.IsEnabled = true;
                Password.Focus();
            }
        }
    }
}