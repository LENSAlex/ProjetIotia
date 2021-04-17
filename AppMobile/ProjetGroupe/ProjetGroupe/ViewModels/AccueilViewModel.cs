
using Android;
using Android.App;
using Android.Content;
using AndroidX.Core.App;
using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    /// <summary>
    /// View de la page d'Accueil
    /// </summary>
    public class AccueilViewModel : BaseViewModel
    {
        /// <summary>
        /// Command au click du bouton
        /// </summary>
        public Command AlertCovid { get; }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public AccueilViewModel()
        {
            var listView = new ListView();
            AlertCovid = new Command(NotifCovid);
        }
        /// <summary>
        /// Méthode éxecuté par la commande lors du click du bouton
        /// </summary>
        public void NotifCovid()
        {
            Personne personne = Personne.IsLogged();
            if (personne != null)
            {
                CasCovid cas = new CasCovid()
                {
                    DateDeContamination = DateTime.Now,
                    PersonneId = personne.Id
                };
                CasCovid.SendAlert(cas);
                personne.RappelMail(personne);
                SendNotification();
            }
        }
        /// <summary>
        /// Méthoed asynchrone pour envoyé la notification
        /// </summary>
        public async void SendNotification()
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("SendNotif", "1");
            await Alerte.SendNotification();

        }
    }
}



