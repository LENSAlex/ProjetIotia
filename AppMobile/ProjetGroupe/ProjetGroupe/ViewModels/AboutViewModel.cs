using Newtonsoft.Json;
using ProjetGroupe.Services;
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

namespace ProjetGroupe.ViewModels
{
    public class AboutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Equipes> items { get; set; }
        public ObservableCollection<Equipes> Items
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
            Items = await Equipes.List();
        }
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class Equipes
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("disponible")]
        public bool Disponible { get; set; }
        public static Task<ObservableCollection<Equipes>> List()
        {
            return CapteurManager.RefreshDataAsync();
        }
        public static Task<Equipes> Load(int id)
        {
            return CapteurManager.Load(id);
        }
    }
}
