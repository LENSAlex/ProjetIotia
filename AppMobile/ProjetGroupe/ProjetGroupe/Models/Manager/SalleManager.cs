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
    internal static class SalleManager
    {

        //Cette fonction doit nous donner la liste des données (capteurs, co2, consommation de la salle à un instanté)
        internal static async Task<Salle> LoadSalleBy(int id)
        {
            var httpClient = new HttpClient();
            Salle Items = null;

            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string WebAPIUrl = "http://51.77.137.170:8080/equipes";
            var uri = new Uri(WebAPIUrl);

            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<Salle>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
