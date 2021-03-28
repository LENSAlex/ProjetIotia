using ProjetGroupe.Services;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ProjetGroupe.ViewModels.AboutViewModel;
using static ProjetGroupe.Views.AboutPage;

namespace ProjetGroupe.Views
{
    public partial class SmartOfficePage : ContentPage
    {
        RestService _restService;

        public SmartOfficePage()
        {
            InitializeComponent();
            BindingContext = new SmartOfficeViewModel();
            _restService = new RestService();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.

        //Select sur le choix du produit
       // PopUp ou alert validation
       //envoie de msg ou mail ou insert dans bdd

        //For example webrequest
        async void OnButtonClicked(object sender, EventArgs e)
        {
     //       List<WebRequestProperty> repositories = await _restService.GetRepositoriesAsync(Constants.WebRequest);
           // collectionView.ItemsSource = repositories;
        }
    }
}