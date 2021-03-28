using ProjetGroupe.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class SmartBuildingViewModel : BaseViewModel
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
        public Command PerformSearch;
        private string text;
        private string description;
        public string SearchResults { get; set; }
        public SmartBuildingViewModel()
        {
            OnRefresh = new Command(OnRefreshing);
        }
        public Command OnRefresh;
        //public string ListPersonne { get => Personne(Email); }
        private string Personnes(string query)
        {
            var ListPersonne = new Personne();
            ListPersonne = ListPersonne.SearchMail(email: query);
            return ListPersonne.Email;
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            SearchResults = Personnes(searchBar.Text);
        }
        void OnTap(object sender, ItemTappedEventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("TAPED:", "Informations incorrectes", "Ok");
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Erreur:", "Informations incorrectes", "Ok");
        }

        public void OnRefreshing()
        {
            var personne = Personne.IsLogged();
            if (personne != null)
            {

            }
            //make sure to end the refresh state

        }
        // public string Email { get; set; }

        //   public PropertyChangedEventHandler PropertyChanged;


        //  List<Personne> SearchResults = new List<Personne>();

        //public ICommand PerformSearch => new Command<Personne>((string query) =>
        //{
        //    SearchResults = Personne.Search(query);
        //});

        //private List<string> searchResults = DataService.Fruits;
        //public List<string> SearchResults
        //{
        //    get
        //    {
        //        return searchResults;
        //    }
        //    set
        //    {
        //        searchResults = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        private string GetMail()
        {
            var personne = Personne.IsLogged();
            if (personne != null)
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
            foreach (Personne personne in Personne.List())
            {
                listPersonne.Add(new Personne { PersonneType = personne.PersonneType, Id = personne.Id, RFID = personne.RFID });
            }
            return listPersonne;
            //  var tempList = new List<Weather>();


            // return tempList;
        }
    }

}

