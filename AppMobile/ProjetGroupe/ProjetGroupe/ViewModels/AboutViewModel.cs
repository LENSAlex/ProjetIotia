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
        public string countcovid;
        public string CountCovid
        {
            get
            {
                return countcovid;
            }
            set
            {
                countcovid = value;
                RaisepropertyChanged("CountCovid");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public List<CasCovid> items { get; set; }
        public List<CasCovid> Items
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
        public List<CasCovid> itemsB { get; set; }
        public List<CasCovid> ItemsB
        {
            get
            {
                return itemsB;
            }
            set
            {
                itemsB = value;
                RaisepropertyChanged("ItemsB");
            }
        }
        public AboutViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetCovidDep());
            Device.BeginInvokeOnMainThread(() => GetCovidForm());
            Device.BeginInvokeOnMainThread(() => GetCovidAll());
       
        }
        public async void GetCovidDep()
        {
            Items = await CasCovid.ListCasCovidDepartement();
        }
        public async void GetCovidForm()
        {
            ItemsB = await CasCovid.ListCasCovidFormation();
        }
        public async Task<string> GetCovidAll()
        {
            var result = await CasCovid.Count();
            return CountCovid+=result;
        }
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
