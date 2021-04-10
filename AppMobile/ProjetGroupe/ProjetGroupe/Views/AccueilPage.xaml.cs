using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ProjetGroupe.Views
{
    [DesignTimeVisible(false)]
    public partial class AccueilPage : ContentPage
    {
        public AccueilPage()
        {
            InitializeComponent();
            this.BindingContext = new AccueilViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FrameAccueil.TranslationY = 600;
            FrameAccueil.TranslateTo(0, 0, 500, Easing.BounceIn);
        }

    }
}