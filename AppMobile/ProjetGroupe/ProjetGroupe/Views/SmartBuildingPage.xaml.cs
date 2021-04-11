﻿using ProjetGroupe.Models;
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
        public List<Salle> _Salle { get; set; }
        public List<CapteurType> _CapteurType { get; set; }
        public string SearchResults { get; set; }
        public SmartBuildingPage()
        {
            InitializeComponent();
            this.BindingContext = new SmartBuildingViewModel();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            GetResultAsync(searchBar.Text);
            searchResults.ItemsSource = _CapteurType;
        }
        public async void GetResultAsync(string query)
        {
            string result = query += " ";
            _CapteurType = await Salle.ListCapteurBySalleId(result);

        }
        private void OnItemSelected2(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (CapteurType)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
            Shell.Current.GoToAsync($"{nameof(CapteursDetailsPage)}");
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
            searchResults.TranslationY = 600;
            searchResults.TranslateTo(0, 0, 500, Easing.SinInOut);
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            GetResultAsync(searchBar.Text);
            searchResults.ItemsSource = _CapteurType;
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