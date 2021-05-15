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
    /// <summary>
    /// View de la page SmartBuilding
    /// </summary>
    public class SmartBuildingViewModel : BaseViewModel, INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// var item
        /// </summary>
        public ObservableCollection<CapteurType> items { get; set; }
        /// <summary>
        /// ObservableCollection d'item a affiché sur le front
        /// </summary>
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
        /// <summary>
        /// Méthode permettant de charger l'ObservableCollection avec des CapteurType
        /// </summary>
        public async void GetData()
        {
            Items = await CapteurType.List();
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
        /// Affichage des résultat de la recherche
        /// </summary>
        public List<CapteurType> SearchResults { get; set; }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public SmartBuildingViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
        }
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged2;

        /// <summary>
        /// Méthode de changement d'une propriété sur le front
        /// </summary>
        /// <param name="propertyName">nom de la propriété</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

