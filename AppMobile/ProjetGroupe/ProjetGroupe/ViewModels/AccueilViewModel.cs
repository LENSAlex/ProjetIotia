using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public AccueilViewModel()
        {
            var listView = new ListView();

            listView.ItemsSource = Personne.List();

        }
    }
}
