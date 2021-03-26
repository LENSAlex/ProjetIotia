
using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        //public Personne personne { get; set; }
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
                personne.RappelMail(personne);
            }
        }
    }

}

