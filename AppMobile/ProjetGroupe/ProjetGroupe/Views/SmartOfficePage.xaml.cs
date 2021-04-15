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
    public partial class SmartOfficePage : ContentPage
    {
        RestService _restService;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Salle> _Salle { get; set; }
        public Salle _SalleId { get; set; }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public SmartOfficePage()
        {
            InitializeComponent();
            Label1.IsVisible = false;
            this.BindingContext = new SmartOfficeViewModel();
            _restService = new RestService();

            ListEquipement.RefreshCommand = new Command(() => {
                ListEquipement.IsRefreshing = true;
                GetData();
                ListEquipement.IsRefreshing = false;
            });
        }
        public async void GetData()
        {
            ListEquipement.ItemsSource = await Equipement.ListEquipement();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.
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
        public async Task UpdateStockAsync(int idSalle, int idEquip)
        {

            List<Salle> salle = await Salle.ListSalleOfEleve();
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
                SetInfo();
            }
            else
            {
                return;
            }
         
        }
        public async void GetSalle(string numsalle)
        {
            _Salle = await Salle.LoadSalleByNom(numsalle);
        }
        public async Task GetDisplayChoiceAsync(int idEquip)        
        {
            var resultPrompt = await DisplayPromptAsync("Choisissez une salle","Numéro de la salle:");
            GetSalle(resultPrompt);
            if (_Salle != null)
            {
                Salle laSalle = new Salle();
                laSalle.Id_salle = _Salle[0].Id_salle;
                var result = await DisplayAlert("Attention!", "Voulez vous vraiment alterter que ce produit est en pénurie?", "Valider", "Annuler");
                if (result == true)
                {
                    UpdateStockAsync(laSalle.Id_salle, idEquip);
                }
                else
                {
                    return;
                }
            }        
        }

        public void SetInfo()
        {
            Personne personne = Personne.IsLogged();
            personne.RappelMail(personne);
            Label1.Text = "Alerte envoyée avec succès";
            Label1.IsVisible = true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Label1.IsVisible = false;
            Label1.Text = "";
            ListEquipement.TranslationY = 600;
            ListEquipement.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
        //public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    var selectedIndex = (Personne)picker.SelectedItem;
        //    int Id = Convert.ToInt32(selectedIndex.Id);
        //    if (Id != 0)
        //    {
        //        Personne personne = Personne.Load(Id);
        //        if (personne != null)
        //        {
        //            GetDisplayChoiceAsync();
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //}
    }
}