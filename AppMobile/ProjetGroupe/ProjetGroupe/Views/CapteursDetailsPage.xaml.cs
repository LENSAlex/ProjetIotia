using Plugin.SharedTransitions;
using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      
        // public Property Property { get; set; }
        // public string TypeName { get; set; }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    DetailsView.TranslationY = 600;
        //    DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        //}
        protected override void OnDisappearing() 
        { 
            base.OnDisappearing();
            Xamarin.Essentials.SecureStorage.Remove("CapteurId");
        }
    }


}

