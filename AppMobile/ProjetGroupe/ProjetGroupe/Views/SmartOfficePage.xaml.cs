using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ProjetGroupe.ViewModels.AboutViewModel;
using static ProjetGroupe.Views.AboutPage;

namespace ProjetGroupe.Views
{
    /// <summary>
    /// Back du front de la page SmartOffice
    /// </summary>
    public partial class SmartOfficePage : ContentPage
    {
        RestService _restService;
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Liste de CapteurType
        /// </summary>
        public List<CapteurType> _Salle = new List<CapteurType>();
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
        /// Constructeur de la classe
        /// </summary>
        public SmartOfficePage()
        {
            InitializeComponent();
            this.BindingContext = new SmartOfficeViewModel();

            _restService = new RestService();

            ListEquipement.RefreshCommand = new Command(() => {
                ListEquipement.IsRefreshing = true;
                GetData();
                ListEquipement.IsRefreshing = false;
            });
        }
        /// <summary>
        /// Méthode permettrant de charger la liste d'équipement lors dfu refresh de la liste
        /// </summary>
        public async void GetData()
        {
            ListEquipement.ItemsSource = await Equipement.ListEquipement();
        }
        /// <summary>
        /// Méthode appelée lors de la sélection d'un item de la liste d'équipement
        /// </summary>
        /// <param name="sender">La sélection</param>
        /// <param name="e">L'évènement de sélection</param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Equipement)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            if(ide != 0)
            {
                Personne personne = Personne.IsLogged();
                if (personne != null)
                {
                    GetDisplayChoiceAsync(ide);
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Méthode qui va mettre la pénurie du produit choisi 
        /// </summary>
        /// <param name="idSalle">Id de la salle en question</param>
        /// <param name="idEquip">Id de l'équipement en question</param>
        /// <returns></returns>
        public async Task UpdateStockAsync(int idSalle, int idEquip)
        {

            Penurie penurie = new Penurie()
            {
                date_maj = DateTime.Now,
                Is_Penurie = true,
                Id_Equipement = idEquip,
                SalleId = idSalle
            };
            var result = await Penurie.UpdateStock(penurie);
            if(result=="Ok")
            {
                SetInfo(penurie);
            }
            else
            {
                DependencyService.Get<ISave>().DisplayAlert("Erreur dans la requête pénurie");
                return;
            }
         
        }
        /// <summary>
        /// Méthode appelée lors de la sélection de l'équipement
        /// </summary>
        /// <param name="idEquip">Récupère l'id de l'équipement grâce à l'évènement OnItemSelected</param>
        /// <returns></returns>
        public async Task GetDisplayChoiceAsync(int idEquip)        
        {
            var resultPrompt = await DisplayPromptAsync("Choisissez une salle","Numéro de la salle:");

            _Salle = await Salle.ListCapteurBySalleName(resultPrompt); 
            if (_Salle != null)
            {
                CapteurType laSalle = new CapteurType();
                laSalle.SalleId = _Salle[0].SalleId;
                var result = await DisplayAlert("Attention!", "Voulez vous vraiment alterter que ce produit est en pénurie?", "Valider", "Annuler");
                if (result == true)
                {
                    UpdateStockAsync(laSalle.SalleId, idEquip);
                }
                else
                {
                    DependencyService.Get<ISave>().DisplayAlert("Erreur lors de l'envois de l'alerte pénurie");
                    return;
                }
            }        
        }
        /// <summary>
        /// Méthode appelée à la fin du traitement de l'envoie de la pénurie dans la base de donnée
        /// </summary>
        /// <param name="penurie">Objet Penurie</param>
        public void SetInfo(Penurie penurie)
        {
            Personne personne = Personne.IsLogged();
            personne.RappelMailPenurie(personne, penurie);
            DependencyService.Get<ISave>().DisplayAlert("Alerte pénurie envoyée avec succès");
        }
        /// <summary>
        /// Méthode exécuté lors de l'apparition de la page
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListEquipement.TranslationY = 600;
            ListEquipement.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
    }
}