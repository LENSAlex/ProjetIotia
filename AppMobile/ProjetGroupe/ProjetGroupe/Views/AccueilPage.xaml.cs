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
    public partial class AccueilPage : ContentView
    {
        public AccueilPage()
        {
            InitializeComponent();

            //Page accueil faire trois boutons pour 1)eCovid => sur alerte/notifcation ou je ne notifie moi même en envoyant une alerte.
            //2)SmartBuilding => affichage des énergie, Co2, température 
            //3)SmartOffice => alerte à pénurie de produit avec choix du produit.
            //Page de login
            //page de logout
            //Managers 
        }
    }
}