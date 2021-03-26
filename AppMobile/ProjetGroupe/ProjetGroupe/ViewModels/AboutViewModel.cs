using Newtonsoft.Json;
using ProjetGroupe.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using ProjetGroupe.Views;

namespace ProjetGroupe.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        //public List<WebRequestProperty> collectionView { get; set; } = new List<WebRequestProperty>();


        public AboutViewModel()
        {
        }


        private string username;
        AboutPage ap = new AboutPage();
     //   public string Username { get => ap.Username; }


    }

    //  public ICommand OpenWebCommand { get; }
}
