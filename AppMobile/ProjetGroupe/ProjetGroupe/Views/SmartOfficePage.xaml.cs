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
            this.BindingContext = new SmartOfficeViewModel();
            _restService = new RestService();

            WeathersList.RefreshCommand = new Command(() => {
                WeathersList.IsRefreshing = true;
                GetData();
                WeathersList.IsRefreshing = false;
            });
        }
        public async void GetData()
        {
            WeathersList.ItemsSource = await Equipement.ListEquipement();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Equipement)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            if(ide != 0)
            {
                Personne personne = Personne.Load(ide);
                if (personne != null)
                {
                    GetDisplayChoiceAsync();
                }
                else
                {
                    return;
                }
            }
        }
        public async Task UpdateStockAsync()
        {
            Salle salle = new Salle();
            Equipement equipement = new Equipement();
            Penurie penurie = new Penurie()
            {
                date_maj = DateTime.Now,
                Is_Penurie = true,
                Id_Equipement = 1,
                SalleId = 1
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
        public async Task GetDisplayChoiceAsync()
        {
            var result = await DisplayAlert("Attention!", "Voulez vous vraiment alterter que ce produit est en pénurie?", "Valider", "Annuler");
            if (result == true)
            {
                UpdateStockAsync();
                //result = false;
            }
            else
            {
                return;
            }
        }

        public void SetInfo()
        {
            //personne.RappelMail(personne);
            Label1.Text = "Alerte envoyée avec succès";
            Label1.IsVisible = true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            WeathersList.TranslationY = 600;
            WeathersList.TranslateTo(0, 0, 500, Easing.SinInOut);
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