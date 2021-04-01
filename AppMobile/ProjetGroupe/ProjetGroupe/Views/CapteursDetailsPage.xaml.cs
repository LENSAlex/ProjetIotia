﻿using Plugin.SharedTransitions;
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
        public async Task GetCapteur()
        {
            Capteur = await Capteur.Load(Convert.ToInt32(CapteurId));
        }
        public CapteursDetailsPage()
        {
            CapteurId = Xamarin.Essentials.SecureStorage.GetAsync("CapteurId").Result;
            //Capteur = Capteur.Load(Convert.ToInt32(CapteurId));
            Device.BeginInvokeOnMainThread(() => GetCapteur());

            InitializeComponent();
            this.BindingContext = this;

        }

        public void OnImageButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            Xamarin.Essentials.SecureStorage.Remove("CapteurId");
            this.Navigation.PopAsync();
        }

        // public Property Property { get; set; }
        // public string TypeName { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
        protected override void OnDisappearing() 
        { 
            base.OnDisappearing();
            Xamarin.Essentials.SecureStorage.Remove("CapteurId");
        }
        public void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
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

