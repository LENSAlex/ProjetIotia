using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    /// <summary>
    /// Back du front de la page SmartBuilding 2
    /// </summary>
    public partial class eCovidPage : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode de changement d'une propriété sur le front
        /// </summary>
        /// <param name="propertyName">nom de la propriété</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Getter/Setter Liste de salle
        /// </summary>
        public List<Salle> _Salle { get; set; }
        /// <summary>
        /// Getter/Setter Liste de CapteurType
        /// </summary>
        public List<CapteurType> _CapteurType { get; set; }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public eCovidPage()
        {
            InitializeComponent();
            this.BindingContext = new eCovidViewModel();
            GetData();
            ListCapteur.RefreshCommand = new Command(() => {
                ListCapteur.IsRefreshing = true;
                GetData();
                ListCapteur.IsRefreshing = false;
            });
        }
        /// <summary>
        /// Méthode permettant de remplir la liste par la liste de CapteurType au refresh de celle-ci
        /// </summary>
        public async void GetData()
        {
            ListCapteur.ItemsSource = await CapteurType.List();
        }
        /// <summary>
        /// Evènement lors de la sélection d'un item de la liste
        /// </summary>
        /// <param name="sender">La sélection</param>
        /// <param name="e">L'évènement de sélection</param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (CapteurType)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            SecureStorage.SetAsync("CapteurId", ide.ToString());
            SecureStorage.SetAsync("BoxName", obj.Libelle.ToString());
            SecureStorage.SetAsync("NomBat", obj.Nom.ToString());
            SecureStorage.SetAsync("Liste", "Liste");
            Application.Current.MainPage = new CapteursDetailsPage();
        }
        /// <summary>
        /// Evènement exécuté quand la page apparaît
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListCapteur.TranslationY = 600;
            ListCapteur.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
    }
}