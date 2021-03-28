using Newtonsoft.Json;
using ProjetGroupe.ViewModels;
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
    internal static class CapteurManager
    {
        internal static async Task<Equipes> Load(int id)
        {
            var httpClient = new HttpClient();
            Equipes Items = null;

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
                    Items = JsonConvert.DeserializeObject<Equipes>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<ObservableCollection<Equipes>> RefreshDataAsync()
        {
            var httpClient = new HttpClient();
            ObservableCollection<Equipes> list = new ObservableCollection<Equipes>();
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
                    list = JsonConvert.DeserializeObject<ObservableCollection<Equipes>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<ObservableCollection<Capteur>> ListCapteur()
        {
            var httpClient = new HttpClient();
            ObservableCollection<Capteur> list = new ObservableCollection<Capteur>();
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
                    list = JsonConvert.DeserializeObject<ObservableCollection<Capteur>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<Capteur> LoadCapteur(int id)
        {
            var httpClient = new HttpClient();
            Capteur Items = null;

            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string WebAPIUrl = "http://51.77.137.170:8080/equipes/" + id;
            var uri = new Uri(WebAPIUrl);

            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<Capteur>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
