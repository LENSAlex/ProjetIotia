using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class SmartOfficeViewModel : BaseViewModel, INotifyPropertyChanged
    {
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

        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SmartOfficeViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
        }
        public async void GetData()
        {
            Items = await Equipement.ListEquipement();
        }
        
    }

}
