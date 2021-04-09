using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.Models.Manager
{
    internal static class EquipementManager
    {
        internal static async Task<ObservableCollection<Equipement>> ListEquipement()
        {
            var httpClient = new HttpClient();
            ObservableCollection<Equipement> list = new ObservableCollection<Equipement>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.WebServiceURI + "/Batiment/ListEquipement";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<ObservableCollection<Equipement>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
