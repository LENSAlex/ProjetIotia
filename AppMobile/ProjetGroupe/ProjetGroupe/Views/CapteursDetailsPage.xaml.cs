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
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime Date { get; set; } = DateTime.Now;
        public string CapteurId { get; set; }

        public string valmoy;
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
        public string vallast;
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
        public string unit;
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
        public string libel;
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
        public string libeltype;
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
        public string boxname;
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
        public string nombat;
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
        public async void GetValeur()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.ListValeurLast(Convert.ToInt32(CapteurId));
            foreach (Historique histo in histoList)
            {

            }
        }
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
        public async void GetLibelType()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.Load(Convert.ToInt32(CapteurId));
            if (histoList != null)
            {
                LibelleType = Convert.ToString(histoList[0].LibelleType);
            }
        }
        public async void GetLibel()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.Load(Convert.ToInt32(CapteurId));
            if (histoList != null)
            {
                Libelle = Convert.ToString(histoList[0].Libelle);
            }
        }
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
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

