﻿using Newtonsoft.Json;
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
        public async void GetData()
        {
            Items = await Equipes.List();
        }
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Personne personne { get; set; }

        private DateTime date = DateTime.Now;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }
        //Pour la page accueil faire 2 boutons 1 pour aller sur E-Covid un pour aller sur sMartBuilding
        public string Email { get => GetMail(); }
        private string temp;
        public string Temp { get => temp; set => SetProperty(ref temp, value); }
        public List<Personne> Weathers { get => GetPersonne(); }
        public Command PerformSearch;
        public string SearchResults { get; set; }
        public SmartBuildingViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
        }

        public Command OnRefresh;
        private string Personnes(string query)
        {
            var ListPersonne = new Personne();
            ListPersonne = ListPersonne.SearchMail(email: query);
            return ListPersonne.Email;
        }

        private string GetMail()
        {
            var personne = Personne.IsLogged();
            if (personne != null)
            {
                string email = personne?.Email;
                return email;
            }
            else
            {
                return "null";
            }
        }
        private List<Personne> GetPersonne()
        {
            List<Personne> listPersonne = new List<Personne>();
            foreach (Personne personne in Personne.List())
            {
                listPersonne.Add(new Personne { PersonneType = personne.PersonneType, Id = personne.Id, RFID = personne.RFID });
            }
            return listPersonne;
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

