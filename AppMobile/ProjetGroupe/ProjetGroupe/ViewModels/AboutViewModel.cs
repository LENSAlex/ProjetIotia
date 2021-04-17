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
    /// <summary>
    /// View de la page About
    /// </summary>
    public class AboutViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// var countcovid
        /// </summary>
        public string countcovid;
        /// <summary>
        /// Affichage du nombre de cas
        /// </summary>
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
        /// <summary>
        /// Event de changement de string sur le front
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// var item
        /// </summary>
        public List<CasCovid> items { get; set; }
        /// <summary>
        /// Affichage de la liste de CasCovid
        /// </summary>
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
        /// <summary>
        /// var itemB
        /// </summary>
        public List<CasCovid> itemsB { get; set; }
        /// <summary>
        /// Affichage de la liste de CasCovid numéro 2
        /// </summary>
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
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public AboutViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetCovidDep());
            Device.BeginInvokeOnMainThread(() => GetCovidForm());
            Device.BeginInvokeOnMainThread(() => GetCovidAll());
       
        }
        /// <summary>
        /// Méthode asynchrone chargeant la liste 1 par le liste de cascovid par dépatement
        /// </summary>
        public async void GetCovidDep()
        {
            Items = await CasCovid.ListCasCovidDepartement();
        }
        /// <summary>
        /// Méthode asynchrone chargeant la liste 2 par le liste de cascovid par formation
        /// </summary>
        public async void GetCovidForm()
        {
            ItemsB = await CasCovid.ListCasCovidFormation();
        }
        /// <summary>
        /// Méthode asynchrone chargeant le nombre de cas covid
        /// </summary>
        public async Task<string> GetCovidAll()
        {
            var result = await CasCovid.Count();
            return CountCovid+=result;
        }
        /// <summary>
        /// Event de changement back/front de Xamarin
        /// </summary>
        /// <param name="propertyName">nom de la propriété a changer</param>
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
