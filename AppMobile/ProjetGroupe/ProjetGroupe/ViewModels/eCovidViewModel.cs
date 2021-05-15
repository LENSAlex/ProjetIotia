using ProjetGroupe.Models;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    /// <summary>
    /// View SmartBuilding 2 
    /// </summary>
    public class eCovidViewModel : BaseViewModel
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
        /// Affichage de l'ObservableCollection de CapteurType
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
        /// Méthode asynchrone permettant de remplir Items de la liste d'ObservableCollection de CapteurType
        /// </summary>
        public async void GetData()
        {
            Items = await CapteurType.List();
        }
        /// <summary>
        /// Evènement de changement de propriété
        /// </summary>
        /// <param name="propertyName">nom de la propriété</param>
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Commande de click sur un bouton
        /// </summary>
        public Command ClickedTest { get; }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public eCovidViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
            //Commande de click sur le bouton Générer PDF
            ClickedTest = new Command(OnClickedTestClickedAsync);
        }
        /// <summary>
        /// Méthoed exécuté lors du click sur le bouton de génération de Pdf
        /// </summary>
        /// <param name="obj">Le click</param>
        private async void OnClickedTestClickedAsync(object obj)
        {
            List<Historique> listeHisto = new List<Historique>();
            listeHisto = await Historique.ListHistorique();
            if (listeHisto != null)
            {
                List<Historique> data = new List<Historique>();
                //on récupère toutes les lignes de notre historique de mesures
                foreach (Historique histo in listeHisto)
                {
                    //On en fait une nouvelle liste
                    data.Add(new Historique
                    {
                        Id_device = histo.Id_device,
                        Libelle = histo.Libelle,
                        LibelleType = histo.LibelleType,
                        Valeur = histo.Valeur,
                        Unite = histo.Unite
                    });
                }
                //Qu'on envoie dans la fonction de génération de pdf qu'il va ensuite utiliser
                Personne.GeneratePdfAsync(40, data);                
            }
        }
    }
}
