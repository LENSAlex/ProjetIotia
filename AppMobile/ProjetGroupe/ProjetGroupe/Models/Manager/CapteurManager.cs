using Newtonsoft.Json;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.Models.Manager
{
    /// <summary>
    /// Classe Manager Capteur
    /// </summary>
    internal static class CapteurManager
    {
        /// <summary>
        /// Requête GET vers le serveur NodeJS permettant de lister les capteurs
        /// </summary>
        /// <returns>Une liste de CapteurType ou null si erreur</returns>
        internal static async Task<ObservableCollection<CapteurType>> ListCapteur()
        {
            var httpClient = new HttpClient();
            ObservableCollection<CapteurType> list = new ObservableCollection<CapteurType>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.WebServiceURI + "/Capteur/ListCapteur";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<ObservableCollection<CapteurType>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}


