using ProjetGroupe.Models;
using System;
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
        private string text;
        private string description;
        public string SearchResults { get; set; }
        public SmartBuildingViewModel()
        {

        }

        //public string ListPersonne { get => Personne(Email); }
        private string Personne(string query)
        {
            var ListPersonne = new Personne();
            ListPersonne = ListPersonne.SearchMail(email: query);
            return ListPersonne.Email;
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            SearchResults = Personne(searchBar.Text);
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
    }
}
