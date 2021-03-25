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
    public partial class eCovidPage : ContentPage
    {
        //Page accueil faire trois boutons pour 1)eCovid => sur alerte/notifcation ou je ne notifie moi même en envoyant une alerte.
        public eCovidPage()
        {
            InitializeComponent();
            this.BindingContext = new eCovidViewModel();
        }
    }
}