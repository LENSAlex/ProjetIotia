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
                ListPersonne = GetJobsInfo(),
                Id = GetId()
                
            };
            _restService = new RestService();
            //  Picker.ItemDisplayBinding.FallbackValue = personne.RFID;
        }
        private List<Personne> GetJobsInfo()
        {
            var list = Personne.List();
            return list.ToList();
        }
        private List<int> GetId()
        {
            List<int> list = new List<int>();
            foreach(Personne personne in Personne.List())
            {
                list.Add(personne.Id);
            }
            return list.ToList();
        }
        //3)SmartOffice => alerte à pénurie de produit avec choix du produit.

        //Select sur le choix du produit
        // PopUp ou alert validation
        //envoie de msg ou mail ou insert dans bdd

        //For example webrequest
        //   async void OnButtonClicked(object sender, EventArgs e)
        //   {
        //       var obj = e.LoadFromXaml as Equipes;
        //       var ide = Convert.ToInt32(obj.Id);
        //       Penurie penurie = Penurie.Load()
        ////       List<WebRequestProperty> repositories = await _restService.GetRepositoriesAsync(Constants.WebRequest);
        //      // collectionView.ItemsSource = repositories;
        //   }
        //Voir poure remettre tout va en void
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            // var obj = (Personne)e.SelectedItem;
            //   var Id = Convert.ToInt32(obj.Id);
            int Id = 1;
            int selectedIndex = picker.SelectedIndex;
            Equipement equipement = new Equipement(); // A Remplacer par l'id de l'quipement choisi par le selected item
            Salle salle = new Salle(); // trouver un moyen de récuperer l'id de la salle.
            if (Id != 0)
            {
                Personne personne = Personne.Load(Id);
                if (personne != null)
                {
                    bool result = true;
                   // var result = await DisplayAlert("Attention!", "Voulez vous vraiment alterter que ce produit est en pénurie?", "Valider", "Annuler");
                    if (result == true)
                    {
                        Penurie penurie = new Penurie()
                        {
                            date_maj = DateTime.Now,
                            Is_Penurie = true,
                            Id_Equipement = equipement.Id,
                            SalleId = salle.Id
                        };
                    //    await Penurie.UpdateStock(penurie);
                        personne.RappelMail(personne);
                        //Envoie d'une notification
     
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}