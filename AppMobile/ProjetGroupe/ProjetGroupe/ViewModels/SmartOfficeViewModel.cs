using ProjetGroupe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjetGroupe.ViewModels
{
    public class SmartOfficeViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string text;
        private string description;
        public Personne personne { get; set; } = new Personne();
        public List<int> Id { get; set; }
        public List<string> Email { get; set; }
        public List<Personne> ListPersonne { get; set; } = new List<Personne>();
        public SmartOfficeViewModel()
        {
          //  ListPersonne = Personne.List();
            
        }
        List<Personne> jobList;
        public List<Personne> JobList
        {
            get { return jobList; }
            set
            {
                if (jobList != value)
                {
                    jobList = value;
                    OnPropertyChanged();
                }
            }
        }

        Personne selectedJob;
        public Personne SelectedJob
        {
            get { return selectedJob; }
            set
            {
                if (selectedJob != value)
                {
                    selectedJob = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
