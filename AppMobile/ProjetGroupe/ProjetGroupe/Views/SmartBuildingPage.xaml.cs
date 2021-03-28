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

        public Personne _Personne { get; set; }
        public string SearchResults { get; set; }
        public SmartBuildingPage()
        {
            InitializeComponent();
            this.BindingContext = new SmartBuildingViewModel();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            SearchResults = PersonneSearch(searchBar.Text);
        }
        private string PersonneSearch(string query)
        {
            _Personne = Personne.SearchLike(query);
            if (_Personne != null)
            {
                return _Personne?.Email;
            }
            else
            {
                return "null";
            }

        }
    }
      
    //2)SmartBuilding => affichage des énergie, Co2, température 

}