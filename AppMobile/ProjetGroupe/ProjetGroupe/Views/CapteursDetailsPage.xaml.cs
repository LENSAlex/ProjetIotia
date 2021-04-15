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

        public Capteur Capteur { get; set; }
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime Date { get; set; } = DateTime.Now;
        public async Task GetCapteur()
        {
           // Capteur = await Capteur.Load(Convert.ToInt32(CapteurId));
        }
        public CapteursDetailsPage()
        {
            CapteurId = SecureStorage.GetAsync("CapteurId").Result;
            //Device.BeginInvokeOnMainThread(() => GetCapteur());
            GetValeurLast();
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
        }
        public async void GetValeurLast()
        {
            List<Historique> histoList = new List<Historique>();
            histoList = await Historique.ListValeurLast(Convert.ToInt32(CapteurId));
            ValMoy = Convert.ToString(histoList[0].Valeur);
            Libelle = Convert.ToString(histoList[0].Libelle);
            Unite = Convert.ToString(histoList[0].Unite);
            LibelleType = Convert.ToString(histoList[0].LibelleType);
        }
        public void OnImageButtonClicked(object sender, EventArgs e)
        {
            var liste = SecureStorage.GetAsync("Liste").Result;
            if(liste!=null)
            {
                Shell.Current.GoToAsync($"{nameof(eCovidPage)}");
                SecureStorage.Remove("Liste");
                SecureStorage.Remove("CapteurId");
            }
            else
            {
                Shell.Current.GoToAsync($"{nameof(SmartBuildingPage)}");
                SecureStorage.Remove("CapteurId");
            }
        }
        public void OnImageButtonClicked2(object sender, EventArgs e)
        {
            var liste = SecureStorage.GetAsync("Liste").Result;
            if (liste != null)
            {
                Shell.Current.GoToAsync($"{nameof(eCovidPage)}");
                SecureStorage.Remove("Liste");
                SecureStorage.Remove("CapteurId");
            }
            else
            {
                Shell.Current.GoToAsync($"{nameof(SmartBuildingPage)}");
                SecureStorage.Remove("CapteurId");
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
        }
        //public void TapGestureRecognizer_Tapped(Object sender, EventArgs e)
        //{
        //    var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        //    Action<double> callback = input => DetailsView.HeightRequest = input;
        //    double startHeight = mainDisplayInfo.Height / 3;
        //    double endiendHeight = 0;
        //    uint rate = 32;
        //    uint length = 500;
        //    Easing easing = Easing.SinOut;
        //    DetailsView.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);
        //}
   
    }


}

