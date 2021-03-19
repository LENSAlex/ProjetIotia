using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmartOfficePage : ContentView
    {
        public SmartOfficePage()
        {
            InitializeComponent();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.
    }
}