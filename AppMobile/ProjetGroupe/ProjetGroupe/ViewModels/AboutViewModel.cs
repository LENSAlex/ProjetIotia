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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ProjetGroupe.ViewModels
{
    public class AboutViewModel : BaseViewModel, INotifyPropertyChanged
    {
        //public List<WebRequestProperty> collectionView { get; set; } = new List<WebRequestProperty>();
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Equipes> items;

        public List<Equipes> Items
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


        async void GetData()
        {
            Items = await RefreshDataAsync();
        }
        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public AboutViewModel()
        {
            items = new List<Equipes>();
            GetData();
        }
        public async System.Threading.Tasks.Task<List<Equipes>> RefreshDataAsync()
        {
            var httpClient = new HttpClient();

            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = "http://51.77.137.170:8080/equipes"; // Set your REST API URL here.
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    //Items = JObject.Parse(content);
                    //string test = jsonData.ToString();
                    Items = JsonConvert.DeserializeObject<List<Equipes>>(content);
                    
                    //for (int i = 0; (JArray)jsonData["data"].lengh; i++)
                    //{
                    //    var data = jsonData[i - 1];
                    //}
                    //   Items = new SJavaScriptSerializer().Deserialize<Equipes>(content);
                    return Items;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
}
    public class Equipes
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("disponible")]
        public bool disponible { get; set; }
    }


}
