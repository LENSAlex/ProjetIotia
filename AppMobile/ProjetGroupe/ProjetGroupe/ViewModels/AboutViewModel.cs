using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using ProjetGroupe.Views;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Linq;
using ProjetGroupe.Models.Manager;
using ProjetGroupe.Models;

namespace ProjetGroupe.ViewModels
{
    public class AboutViewModel : INotifyPropertyChanged
    {
        public string CasAll { get; set; } = "12";
        public string CasBat { get; set; } = "14";
        public string CasSalle { get; set; } = "16";

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Equipement> items { get; set; }
        public ObservableCollection<Equipement> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisepropertyChanged("Items");
            }
        }
        public AboutViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
        }
        public async void GetData()
        {
            Items = await Equipement.ListEquipement();
        }
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
