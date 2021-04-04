using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    public partial class SmartBuildingPage : ContentPage, INotifyPropertyChanged
    {

        public List<Personne> _Personne { get; set; }
        public string SearchResults { get; set; }
        public SmartBuildingPage()
        {
            InitializeComponent();
            this.BindingContext = new SmartBuildingViewModel();
        }
        private bool _isBusy;
        public bool isBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;

                OnPropertyChanged("isBusy");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            searchResults.ItemsSource = PersonneSearch(searchBar.Text);
        }
        private List<Personne> PersonneSearch(string query)
        {
            _Personne = Personne.SearchLike(query);
            return _Personne;
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Equipes)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            //Application.Current.MainPage.DisplayAlert("Capteur:", "Informations "+ ide, "Ok");
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
            Xamarin.Forms.Application.Current.MainPage = new CapteursDetailsPage();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        private void OnItemSelected2(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Personne)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            //Application.Current.MainPage.DisplayAlert("Capteur:", "Informations "+ ide, "Ok");
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
            Xamarin.Forms.Application.Current.MainPage = new CapteursDetailsPage();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }

        private void WeathersList_Refreshing(object sender, EventArgs e)
        {
            var personne = Personne.IsLogged();
            if (personne != null)
            {
                IsBusy = false;
            }
        }
    }
}
      
    //2)SmartBuilding => affichage des énergie, Co2, température 

    //Recherche de données en fonction de la salle entrée
