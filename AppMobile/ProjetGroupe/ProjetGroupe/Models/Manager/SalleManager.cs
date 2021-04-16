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
        internal static async Task<List<Salle>> LoadSalleByNom(string nomSalle)
        {
            var httpClient = new HttpClient();
            List<Salle> Items = new List<Salle>();

            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string WebAPIUrl = Config.WebServiceURI + "/Personne/ListSalleEleve/" + nomSalle;
            var uri = new Uri(WebAPIUrl);

            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Salle>>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<List<Salle>> ListSalleOfEleve()
        {
            var httpClient = new HttpClient();
            List<Salle> Items = new List<Salle>();

            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string WebAPIUrl = Config.WebServiceURI + "/Personne/ListSalleEleve/" + Personne.IsLogged().Id;
            var uri = new Uri(WebAPIUrl);

            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Salle>>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<List<CapteurType>> ListCapteurBySalleId(string nomSalle)
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
