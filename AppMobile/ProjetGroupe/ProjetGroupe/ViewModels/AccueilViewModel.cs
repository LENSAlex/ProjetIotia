
using Android;
using Android.App;
using Android.Content;
using AndroidX.Core.App;
using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    /// <summary>
    /// View de la page d'Accueil
    /// </summary>
    public class AccueilViewModel : BaseViewModel, INotifyPropertyChanged
    {
        /// <summary>
        /// Command au click du bouton
        /// </summary>
        public Command AlertCovid { get; }

        /// <summary>
        /// displaymsg
        /// </summary>
        public string displaymsg;
        /// <summary>
        /// Binding du message affiché sur le front lros de l'envois d'une alerte
        /// </summary>
        public string DisplayMsg
        {
            get
            {
                return displaymsg;
            }
            set
            {
                displaymsg = value;
                RaisepropertyChanged("DisplayMsg");
            }
        }
        /// <summary>
        /// textcolor
        /// </summary>
        public string textcolor;
        /// <summary>
        /// Couleur de ce-dernier
        /// </summary>
        public string TextColor
        {
            get
            {
                return textcolor;
            }
            set
            {
                textcolor = value;
                RaisepropertyChanged("TextColor");
            }
        }
        /// <summary>
        /// Event de changement de string sur le front
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public AccueilViewModel()
        {
            AlertCovid = new Command(NotifCovid);
        }
        /// <summary>
        /// Méthode éxecuté par la commande lors du click du bouton
        /// </summary>
        public void NotifCovid()
        {
            Personne personne = Personne.IsLogged();
            if (personne != null)
            {
                CasCovid cas = new CasCovid()
                {
                    DateDeContamination = DateTime.Now,
                    PersonneId = personne.Id
                };
                var result = CasCovid.SendAlert(cas);
                personne.RappelMail(personne);
                SendNotification();

            }
        }
        /// <summary>
        /// Méthode asynchrone pour envoyé la notification
        /// </summary>
        public async void SendNotification()
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("SendNotif", "1");
            await Alerte.SendNotification();

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



