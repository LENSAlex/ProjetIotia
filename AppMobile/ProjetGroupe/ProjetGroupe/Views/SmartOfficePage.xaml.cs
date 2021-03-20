using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    public partial class SmartOfficePage : ContentPage
    {
        public SmartOfficePage()
        {
            InitializeComponent();
            BindingContext = new SmartOfficeViewModel();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.
    }
}