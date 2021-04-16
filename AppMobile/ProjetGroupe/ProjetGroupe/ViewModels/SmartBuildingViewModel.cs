using Newtonsoft.Json;
using ProjetGroupe.Models;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class SmartBuildingViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<CapteurType> items { get; set; }
        public ObservableCollection<CapteurType> Items
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
        public async void GetData()
        {
            Items = await CapteurType.List();
        }
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<CapteurType> SearchResults { get; set; }
        public SmartBuildingViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
        }
        public Command OnRefresh;

        public event PropertyChangedEventHandler PropertyChanged2;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

