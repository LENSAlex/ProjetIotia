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
    public partial class SmartBuildingPage : ContentView
    {

        public SmartBuildingPage()
        {
            InitializeComponent();
        }
        //2)SmartBuilding => affichage des énergie, Co2, température 
    }
}