
using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public Personne personne { get; set; }

        private DateTime date = DateTime.Now;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }

     //   public string Email = ;
     //Pour la page accueil faire 2 boutons 1 pour aller sur E-Covid un pour aller sur sMartBuilding
        public string Email { get => GetMail(); }
        private string temp;
        public string Temp { get => temp; set => SetProperty(ref temp, value); }
        public List<Personne> Weathers { get => WeatherData(); }
        public AccueilViewModel()
        {
            var listView = new ListView();

        }
        private string GetMail()
        {
            var personne = Personne.IsLogged();
            if(personne != null)
            {
                string email = personne?.Email;
                return email;
            } 
            else
            {
                return "null";
            }
        }
        private List<Personne> WeatherData()
        {
            List<Personne> listPersonne = new List<Personne>();
            foreach(Personne personne in Personne.List())
            {
                listPersonne.Add(new Personne { PersonneType = personne.PersonneType, Id = personne.Id , RFID = personne.RFID });
            }
            return listPersonne;
          //  var tempList = new List<Weather>();
           

           // return tempList;
        }

    }
    public class Weather
    {
        public string Temp { get; set; }
        public string Date { get; set; }
        public string Icon { get; set; }
    }

}

