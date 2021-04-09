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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<Personne> _Personne { get; set; }
        public string SearchResults { get; set; }
        public SmartBuildingPage()
        {
            InitializeComponent();
            this.BindingContext = new SmartBuildingViewModel();

            WeathersList.RefreshCommand = new Command(() => {
                WeathersList.IsRefreshing = true;
                GetData();
                WeathersList.IsRefreshing = false;
            });
        }
        public async void GetData()
        {
            WeathersList.ItemsSource = await CapteurType.List();
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
            var obj = (CapteurType)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
            Application.Current.MainPage = new CapteursDetailsPage();
            //Go route vers la page (la remettre dans le shell pour permettre le go back
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        private void OnItemSelected2(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (CapteurType)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
            Application.Current.MainPage = new CapteursDetailsPage();
            //Go route vers la page (la remettre dans le shell pour permettre le go back
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            WeathersList.TranslationY = 600;
            WeathersList.TranslateTo(0, 0, 500, Easing.SinInOut);
            searchResults.TranslationY = 600;
            searchResults.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
    }
    //ScrollViews

    //Voir si on peut mettre en place l'Excpander + Animation et background page CapteurDetails + animation listeview
}      //Notification Hub plz
      
    //2)SmartBuilding => affichage des énergie, Co2, température 

    //Recherche de données en fonction de la salle entrée


//arrangé la listviews de façon a voir la liste entière

//Une page complète de la liste des capteurs
//Une page pour la recherche des capteurs