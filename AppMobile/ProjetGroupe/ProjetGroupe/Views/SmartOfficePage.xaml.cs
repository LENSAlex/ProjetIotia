using ProjetGroupe.Models;
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
        Personne personne = new Personne();
        RestService _restService;
        public SmartOfficePage()
        {
            InitializeComponent();
            this.BindingContext = new SmartOfficeViewModel()
            {
                ListPersonne = GetPersonne(),
                Id = GetId(),
                Email = GetMail()
            };
            _restService = new RestService();
        }
        private List<Personne> GetPersonne()
        {
            var list = Personne.List();
            return list.ToList();
        }
        private List<int> GetId()
        {
            List<int> list = new List<int>();
            foreach (Personne personne in Personne.List())
            {
                list.Add(personne.Id);
            }
            return list.ToList();
        }
        private List<string> GetMail()
        {
            List<string> list = new List<string>();
            foreach (Personne personne in Personne.List())
            {
                list.Add(personne.Email);
            }
            return list.ToList();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedIndex = (Personne)picker.SelectedItem;
            int Id = Convert.ToInt32(selectedIndex.Id);
            if (Id != 0)
            {
                Personne personne = Personne.Load(Id);
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
            personne.RappelMail(personne);
            Label1.Text = "Alerte envoyée avec succès";
            Label1.IsVisible = true;
        }
    }
}