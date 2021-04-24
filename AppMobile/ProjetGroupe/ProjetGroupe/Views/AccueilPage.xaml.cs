using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using ProjetGroupe.Models;
using Xamarin.Essentials;
using Android.Widget;
using Android.Content;

namespace ProjetGroupe.Views
{
    /// <summary>
    /// La page d'accueil du shell
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class AccueilPage : ContentPage
    {
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public AccueilPage()
        {
            InitializeComponent();
            this.BindingContext = new AccueilViewModel();
        }
        /// <summary>
        /// Evènement "Quand la page apparaît"
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FrameAccueil.TranslationY = 600;
            FrameAccueil.TranslateTo(0, 0, 500, Easing.BounceIn);
        }
        /// <summary>
        /// Evènement du click sur le bouton alerte
        /// </summary>
        /// <param name="sender">La personne qui click</param>
        /// <param name="e">L'evènement du click</param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            Personne personne = Personne.IsLogged();
            if (personne != null)
            {
                CasCovid cas = new CasCovid()
                {
                    DateDeContamination = DateTime.Now,
                    PersonneId = personne.Id
                };
                SecureStorage.SetAsync("SendNotif", "1");
                NotifyAdmin(cas, personne);
            }
        }
        /// <summary>
        /// Traitement de la requête vers l'API REST
        /// </summary>
        /// <param name="cas">Le cas covid</param>
        /// <param name="personne">La personne qui emet l'alerte</param>
        /// <returns>task</returns>
        public async Task NotifyAdmin(CasCovid cas, Personne personne)
        {
            var resultBool = await DisplayAlert("Attention!", "Envoyer l'alerte ?", "Oui", "Non");
            if (resultBool == true)
            {
                var result = await CasCovid.SendAlert(cas);
                if (result == "Ok")
                {
                    SetInfo(personne);
                }
                else
                {
                    DependencyService.Get<ISave>().DisplayAlert("Erreur lors de l'envois de l'alerte");
                }
            }
        }
        /// <summary>
        /// Méthode pour envoyé le mail et le message d'erreur ou non ainsi que la notification
        /// </summary>
        /// <param name="personne">La personne qui emet l'alerte</param>
        public void SetInfo(Personne personne)
        {
            DependencyService.Get<ISave>().DisplayAlert("Alerte envoyée avec succès");
            personne.RappelMail(personne);
            SendNotification();
        }
        /// <summary>
        /// Méthode asynchrone pour envoyé la requête de notification
        /// </summary>
        public async void SendNotification()
        {
            await Alerte.SendNotification();
        }
    }
}