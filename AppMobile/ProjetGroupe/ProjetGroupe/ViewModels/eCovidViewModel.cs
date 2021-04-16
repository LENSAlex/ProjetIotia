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
    public class eCovidViewModel : BaseViewModel
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
        public Command ClickedTest { get; }
        public eCovidViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
            ClickedTest = new Command(OnClickedTestClickedAsync);
        }

        private async void OnClickedTestClickedAsync(object obj)
        {
            List<Historique> listeHisto = new List<Historique>();
            listeHisto = await Historique.ListHistorique();
            if (listeHisto != null)
            {
                List<Historique> data = new List<Historique>();
                foreach (Historique histo in listeHisto)
                {
                    data.Add(new Historique
                    {
                        Id_device = histo.Id_device,
                        Libelle = histo.Libelle,
                        LibelleType = histo.LibelleType,
                        Valeur = histo.Valeur,
                        Unite = histo.Unite
                    });
                }
                Personne.GeneratePdfAsync(40, data);                
            }
        }
    }
}
