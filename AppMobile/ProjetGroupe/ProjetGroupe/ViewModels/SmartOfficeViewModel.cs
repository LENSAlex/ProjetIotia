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
    /// <summary>
    /// View de la page SmartOffice
    /// </summary>
    public class SmartOfficeViewModel : BaseViewModel, INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// var items
        /// </summary>
        public ObservableCollection<Equipement> items { get; set; }
        /// <summary>
        /// Affichage de l'ObservableCollection d'Equipement sur le front
        /// </summary>
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
        /// Constructeur de la classe
        /// </summary>
        public SmartOfficeViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
        }
        /// <summary>
        /// Méthoed asynchrone permettant de charger la liste d'équipement 
        /// </summary>
        public async void GetData()
        {
            Items = await Equipement.ListEquipement();
        }
        
    }

}
