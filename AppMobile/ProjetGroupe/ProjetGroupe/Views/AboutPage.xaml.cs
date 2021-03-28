
using Newtonsoft.Json;
using ProjetGroupe.Models;
using ProjetGroupe.Models.Manager;
using ProjetGroupe.Services;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ProjetGroupe.ViewModels.AboutViewModel;
using static ProjetGroupe.Views.CapteursDetailsPage;

namespace ProjetGroupe.Views
{
    public partial class AboutPage : ContentPage, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public AboutPage( )
        {
            InitializeComponent();
            this.BindingContext = new AboutViewModel();
        }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Equipes)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            Application.Current.MainPage.DisplayAlert("Capteur:", "Informations "+ ide, "Ok");
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
        }
    }
}

