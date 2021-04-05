using Plugin.SharedTransitions;
using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetGroupe.Views
{

    public partial class CapteursDetailsPage : ContentPage
    {

        public Capteur Capteur { get; set; }
        public string CapteurId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public async Task GetCapteur()
        {
            Capteur = await Capteur.Load(Convert.ToInt32(CapteurId));
        }
        public CapteursDetailsPage()
        {
            CapteurId = SecureStorage.GetAsync("CapteurId").Result;
            Device.BeginInvokeOnMainThread(() => GetCapteur());
            InitializeComponent();
            this.BindingContext = this;

        }

        public void OnImageButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            SecureStorage.Remove("CapteurId");
            this.Navigation.PopAsync();
        }
        public void OnImageButtonClicked2(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            SecureStorage.Remove("CapteurId");
            this.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
        protected override void OnDisappearing() 
        { 
            base.OnDisappearing();
            SecureStorage.Remove("CapteurId");
        }
        public void TapGestureRecognizer_Tapped(Object sender, EventArgs e)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            Action<double> callback = input => DetailsView.HeightRequest = input;
            double startHeight = mainDisplayInfo.Height / 3;
            double endiendHeight = 0;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            DetailsView.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);
        }
   
    }


}

