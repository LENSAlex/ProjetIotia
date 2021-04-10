
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
    public class AccueilViewModel : BaseViewModel
    {
        public Command AlertCovid { get; }
        public AccueilViewModel()
        {
            var listView = new ListView();
            AlertCovid = new Command(NotifCovid);
        }
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
        public async void SendNotification()
        {
            await Alerte.SendNotification();
        }
    }
}



