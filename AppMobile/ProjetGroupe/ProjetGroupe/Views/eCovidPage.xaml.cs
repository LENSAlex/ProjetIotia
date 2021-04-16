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
    public partial class eCovidPage : ContentPage, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<Salle> _Salle { get; set; }
        public List<CapteurType> _CapteurType { get; set; }
        public string SearchResults { get; set; }
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
        public async void GetData()
        {
            ListCapteur.ItemsSource = await CapteurType.List();
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (CapteurType)e.SelectedItem;
            var ide = Convert.ToInt32(obj.Id);
            SecureStorage.SetAsync("CapteurId", ide.ToString());
            SecureStorage.SetAsync("BoxName", obj.Libelle.ToString());
            SecureStorage.SetAsync("NomBat", obj.Nom.ToString());
            SecureStorage.SetAsync("Liste", "Liste");
            Application.Current.MainPage = new CapteursDetailsPage();

       //     Shell.Current.GoToAsync($"{nameof(CapteursDetailsPage)}");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListCapteur.TranslationY = 600;
            ListCapteur.TranslateTo(0, 0, 500, Easing.SinInOut);
        }
    }
}