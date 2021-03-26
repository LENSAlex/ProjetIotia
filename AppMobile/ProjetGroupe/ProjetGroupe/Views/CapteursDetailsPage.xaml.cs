using Plugin.SharedTransitions;
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
        //public CapteursDetailsPage()
        //{

        //}
        public CapteursDetailsPage()
        {
            InitializeComponent();
            //     this.Property = property;
            this.BindingContext = this;
           //  = new SharedTransitionNavigationPage(new CapteursDetailsPage());
        }

        public Property Property { get; set; }

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
