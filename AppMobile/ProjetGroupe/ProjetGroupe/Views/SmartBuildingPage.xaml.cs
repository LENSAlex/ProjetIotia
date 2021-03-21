using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    public partial class SmartBuildingPage : ContentPage
    {
        public string SearchResults { get; set; }
        public SmartBuildingPage()
        {
            InitializeComponent();
            this.BindingContext = new SmartBuildingViewModel();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            SearchResults = Personne(searchBar.Text);
        }
        private string Personne(string query)
        {
            var ListPersonne = new Personne();
            ListPersonne = ListPersonne.SearchMail(email: query);
            return ListPersonne.Email;
        }
        //2)SmartBuilding => affichage des énergie, Co2, température 
    }
}