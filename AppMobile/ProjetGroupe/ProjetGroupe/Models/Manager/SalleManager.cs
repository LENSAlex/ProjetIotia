using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.Models.Manager
{
    /// <summary>
    /// Classe Mannager Salle
    /// </summary>
    internal static class SalleManager
    {
        /// <summary>
        /// Méthoed permettant de charger une liste de capteur via le nom de la salle donnant l'id de la salle, le nom du bâtiment etc..
        /// </summary>
        /// <param name="nomSalle">nom de la salle saisie</param>
        /// <returns>Une liste de CapteurType</returns>
        internal static async Task<List<CapteurType>> ListCapteurBySalleName(string nomSalle)
        {
            var httpClient = new HttpClient();
            List<CapteurType> Items = new List<CapteurType>();

            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string WebAPIUrl = Config.WebServiceURI + "/Capteur/Search/" + nomSalle;
            var uri = new Uri(WebAPIUrl);

            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<CapteurType>>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
