using Plugin.SharedTransitions;
using ProjetGroupe.Models;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetGroupe.Views
{

    public partial class CapteursDetailsPage : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Méthode de changement d'une propriété sur le front
        /// </summary>
        /// <param name="propertyName">nom de la propriété</param>
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Date 
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
        /// <summary>
        /// Id du capteur
        /// </summary>
        public string CapteurId { get; set; }
        /// <summary>
        /// valmoy
        /// </summary>

        public string valmoy;
        /// <summary>
        /// ValeurMoyenne à afficher
        /// </summary>
        public string ValMoy
        {
            get
            {
                return valmoy;
            }
            set
            {
                valmoy = value;
                RaisepropertyChanged("ValMoy");
            }
        }
        /// <summary>
        /// vallast
        /// </summary>
        public string vallast;
        /// <summary>
        /// Dernière valeur à afficher
        /// </summary>
        public string ValLast
        {
            get
            {
                return vallast;
            }
            set
            {
                vallast = value;
                RaisepropertyChanged("ValLast");
            }
        }
        /// <summary>
        /// unit
        /// </summary>
        public string unit;
        /// <summary>
        /// Unité à afficher
        /// </summary>
        public string Unite
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
                RaisepropertyChanged("Unite");
            }
        }
        /// <summary>
        /// libel
        /// </summary>
        public string libel;
        /// <summary>
        /// Libellé à affiché
        /// </summary>
        public string Libelle
        {
            get
            {
                return libel;
            }
            set
            {
                libel = value;
                RaisepropertyChanged("Libelle");
            }
        }
        /// <summary>
        /// libeltype
        /// </summary>
        public string libeltype;
        /// <summary>
        /// LibelleType à afficher
        /// </summary>
        public string LibelleType
        {
            get
            {
                return libeltype;
            }
            set
            {
                libeltype = value;
                RaisepropertyChanged("LibelleType");
            }
        }
        /// <summary>
        /// boxname
        /// </summary>
        public string boxname;
        /// <summary>
        /// Nom de la box à afficher
        /// </summary>
        public string BoxName
        {
            get
            {
                return boxname;
            }
            set
            {
                boxname = value;
                RaisepropertyChanged("BoxName");
            }
        }
        /// <summary>
        /// nombat
        /// </summary>
        public string nombat;
        /// <summary>
        /// Nom du bâtiment à afficher
        /// </summary>
        public string NomBat
        {
            get
            {
                return nombat;
            }
            set
            {
                nombat = value;
                RaisepropertyChanged("NomBat");
            }
        }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public CapteursDetailsPage()
        {
            CapteurId = SecureStorage.GetAsync("CapteurId").Result;
            BoxName = SecureStorage.GetAsync("BoxName").Result;
            NomBat = SecureStorage.GetAsync("NomBat").Result;
            GetValeurLast();
            GetLibel();
            GetLibelType();
            GetValeurMoyenne();
            InitializeComponent();
            this.BindingContext = this;

        }
        /// <summary>
        /// Méthode permettrant de remplir la ValMoy
        /// </summary>
        public async void GetValeurMoyenne()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.ListValeurMoyenne(Convert.ToInt32(CapteurId));
            if (histoList != null)
            {
                string val = Convert.ToString(histoList[0].Moyenne);
                string unit = Convert.ToString(histoList[0].Unite);
                ValMoy = val + " " + unit;
            }
        }
        /// <summary>
        /// Méthode permettrant de remplir la ValLast
        /// </summary>
        public async void GetValeurLast()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.ListValeurLast(Convert.ToInt32(CapteurId));
            if (histoList!= null)
            {
                string val = Convert.ToString(histoList[0].Valeur);
                string unit = Convert.ToString(histoList[0].Unite);
                ValLast = val + " " + unit;
            }

        }
        /// <summary>
        /// Méthode permettrant de remplir le LibelType
        /// </summary>
        public async void GetLibelType()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.Load(Convert.ToInt32(CapteurId));
            if (histoList != null)
            {
                LibelleType = Convert.ToString(histoList[0].LibelleType);
            }
        }
        /// <summary>
        /// Méthode permettrant de remplir le Libelle
        /// </summary>
        public async void GetLibel()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.Load(Convert.ToInt32(CapteurId));
            if (histoList != null)
            {
                Libelle = Convert.ToString(histoList[0].Libelle);
            }
        }
        /// <summary>
        /// Action au click de l'ImageButton sur le front
        /// </summary>
        /// <param name="sender">l'ImageButton</param>
        /// <param name="e">L'Event Click</param>
        public void OnImageButtonClicked(object sender, EventArgs e)
        {
            var liste = SecureStorage.GetAsync("Liste").Result;
            if(liste!=null)
            {
                Application.Current.MainPage = new AppShell();
                Shell.Current.GoToAsync($"{nameof(eCovidPage)}");
                SecureStorage.Remove("Liste");
                SecureStorage.Remove("CapteurId");
                SecureStorage.Remove("BoxName");
                SecureStorage.Remove("NomBat");
            }
            else
            {
                Application.Current.MainPage = new AppShell();
                Shell.Current.GoToAsync($"{nameof(SmartBuildingPage)}");
                SecureStorage.Remove("CapteurId");
                SecureStorage.Remove("BoxName");
                SecureStorage.Remove("NomBat");
            }
        }
        /// <summary>
        /// Evènement "Quand la page apparaît"
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
        /// <summary>
        /// Evènement "Quand la page disparaît"
        /// </summary>
        protected override void OnDisappearing() 
        { 
            base.OnDisappearing();
            SecureStorage.Remove("CapteurId");
            SecureStorage.Remove("Liste");
            SecureStorage.Remove("BoxName");
            SecureStorage.Remove("NomBat");
        }
    }
}

