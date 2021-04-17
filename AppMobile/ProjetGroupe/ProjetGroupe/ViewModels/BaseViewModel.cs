using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    /// <summary>
    /// Généré automatiquement lors de la création du projet
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        bool isBusy = false;
        /// <summary>
        /// Refresh On/Off
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        /// <summary>
        /// Titre de la page
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        /// <summary>
        /// Changement d'état
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="backingStore">backingStore</param>
        /// <param name="value">value</param>
        /// <param name="propertyName">nom de la propriété</param>
        /// <param name="onChanged">action de changement</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Méthode appelé lors du changement d'état d'une prpriété
        /// </summary>
        /// <param name="propertyName">nom de la propriété a changer</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
