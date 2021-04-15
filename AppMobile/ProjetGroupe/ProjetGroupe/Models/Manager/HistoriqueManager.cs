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
    internal static class HistoriqueManager
    {
        internal static async Task<List<Historique>> ListHistorique()
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.WebServiceURI + "/Capteur/List/Historique";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<Historique>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<List<Historique>> ListValeurLast(int CapteurId)
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.WebServiceURI + "/Capteur/ValeurSpecifique/Last/" + CapteurId;
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<Historique>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<List<Historique>> ListValeurMoyenne(int CapteurId)
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.WebServiceURI + "/Capteur/ValeurSpecifique/Moyenne/" + CapteurId;
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<Historique>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
