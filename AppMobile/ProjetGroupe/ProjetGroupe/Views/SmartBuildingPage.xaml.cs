using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGroupe.Views
{
    /// <summary>
    /// Back deu front de la page SmartBuilding
    /// </summary>
    public partial class SmartBuildingPage : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Méthode appellée lors du changement d'état d'une propriété
        /// </summary>
        /// <param name="propertyName">propertyName</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Liste de Salle
        /// </summary>
        public List<Salle> _Salle { get; set; }
        /// <summary>
        /// Liste de CapteurType
        /// </summary>
        public List<CapteurType> _CapteurType { get; set; }
        /// <summary>
        /// Résultat de la recherche
        /// </summary>
        public string SearchResults { get; set; }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public SmartBuildingPage()
        {
            InitializeComponent();
            this.BindingContext = new SmartBuildingViewModel();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        /// <summary>
        /// Evènement lors du changement d'un texte dans la TextBox du front
        /// </summary>
        /// <param name="sender">L'utilisateur qui rentre le texte</param>
        /// <param name="e">Le texte qui change</param>
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            GetResultAsync(searchBar.Text);
            searchResults.ItemsSource = _CapteurType;
        }
        /// <summary>
        /// Remplissage de la liste à chaquement de lettre/chiffre dans la TextBox du front
        /// </summary>
        /// <param name="query">texte dans la TextBox</param>
        public async void GetResultAsync(string query)
        {
            string result = query += " ";
            _CapteurType = await Salle.ListCapteurBySalleName(result);

        }
        /// <summary>
        /// Evènement lors de la sélection d'un item de la liste 
        /// </summary>
        /// <param name="sender">La sélection</param>
        /// <param name="e">L'évènement de sélection</param>
        private void OnItemSelected2(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (CapteurType)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            Xamarin.Essentials.SecureStorage.SetAsync("CapteurId", ide.ToString());
            Xamarin.Essentials.SecureStorage.SetAsync("BoxName", obj.Libelle.ToString());
            Xamarin.Essentials.SecureStorage.SetAsync("NomBat", obj.Nom.ToString());
            Application.Current.MainPage = new CapteursDetailsPage();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        /// <summary>
        /// Méthode exécuté lors de l'apparition de la page
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            searchResults.TranslationY = 600;
            searchResults.TranslateTo(0, 0, 500, Easing.SinInOut);
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        /// <summary>
        /// Méthode exécuté lors de la disparition de la page
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            searchResults.ItemsSource = null;
            searchBar.Text = "";
        }
        /// <summary>
        /// Méthode appelé lors du click sur le bouton rechercher du clavier
        /// </summary>
        /// <param name="sender">Le click sur rechercher</param>
        /// <param name="e">L'évènement de click sur celui-ci</param>
        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            GetResultAsync(searchBar.Text);
            searchResults.ItemsSource = _CapteurType;
        }
    }
}   
