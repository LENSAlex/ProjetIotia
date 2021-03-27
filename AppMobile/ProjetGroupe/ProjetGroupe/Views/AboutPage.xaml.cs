
using Newtonsoft.Json;
using ProjetGroupe.Models;
using ProjetGroupe.Services;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ProjetGroupe.ViewModels.AboutViewModel;
using static ProjetGroupe.Views.CapteursDetailsPage;

namespace ProjetGroupe.Views
{
    public partial class AboutPage : ContentPage
    {
     //   public List<WebRequestProperty> testo { get; set; } = new List<WebRequestProperty>();

        private string username;
        public string Username { get => username; set => username = value; } 
        RestService _restService;
        public AboutPage( )
        {

            _restService = new RestService();

            InitializeComponent();
            this.GetMailAsync();
            this.BindingContext = this;
        }

        public async void GetMailAsync()
        {
            WebRequestProperty test = await _restService.GetRepositoriesAsync(Constants.WebRequest);
            if (test != null)
            {
                username = test.Username;
            }
            else
            {
                username = "null";
            }
        }
        public string GetMail()
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
        async void OnButtonClicked(object sender, EventArgs e)
        {
            WebRequestProperty test = await _restService.GetRepositoriesAsync(Constants.WebRequest);
            // Test.ItemsSource = test;
            //foreach (WebRequestProperty wb in test)
            //{
            //AboutViewModel acc = new AboutViewModel();
            username = test.Username;
            //}

        }
        public class WebRequestProperty
        {
            [JsonProperty("username")]
            public string Username { get; set; }
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
    }

}

