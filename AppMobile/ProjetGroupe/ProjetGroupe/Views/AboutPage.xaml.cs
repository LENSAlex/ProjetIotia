using Newtonsoft.Json;
using ProjetGroupe.Models;
using ProjetGroupe.Models.Manager;
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

            ListCasCovidDep.RefreshCommand = new Command(() => {
                ListCasCovidDep.IsRefreshing = true;
                GetDataDep();
                ListCasCovidDep.IsRefreshing = false;
            });

            ListCasCovidForm.RefreshCommand = new Command(() => {
                ListCasCovidForm.IsRefreshing = true;
                GetDataForm();
                ListCasCovidForm.IsRefreshing = false;
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListCasCovidDep.TranslationY = 600;
            ListCasCovidDep.TranslateTo(0, 0, 500, Easing.SinInOut);
            ListCasCovidForm.TranslationY = 600;
            ListCasCovidForm.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
        public async void GetDataForm()
        {
            ListCasCovidForm.ItemsSource = await CasCovid.ListCasCovidFormation();
        }
        public async void GetDataDep()
        {
            ListCasCovidDep.ItemsSource = await CasCovid.ListCasCovidDepartement();
        }
    }
}

