﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class eCovidPage : ContentView
    {
        //Page accueil faire trois boutons pour 1)eCovid => sur alerte/notifcation ou je ne notifie moi même en envoyant une alerte.
        public eCovidPage()
        {
            InitializeComponent();
        }
    }
}