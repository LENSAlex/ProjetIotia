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
        }
    }
}

