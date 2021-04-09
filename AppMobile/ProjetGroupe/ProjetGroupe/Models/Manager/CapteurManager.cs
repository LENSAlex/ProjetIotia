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
    internal static class CapteurManager
    {
        internal static async Task<Equiquement> Load(int id)
        {
            var httpClient = new HttpClient();
            Equiquement Items = null;

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
                    Items = JsonConvert.DeserializeObject<Equiquement>(content);

                    return Items;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<ObservableCollection<Equiquement>> RefreshDataAsync()
        {
            var httpClient = new HttpClient();
            ObservableCollection<Equiquement> list = new ObservableCollection<Equiquement>();
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
                    list = JsonConvert.DeserializeObject<ObservableCollection<Equiquement>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        internal static async Task<ObservableCollection<CapteurType>> ListCapteur()
        {
            var httpClient = new HttpClient();
            ObservableCollection<CapteurType> list = new ObservableCollection<CapteurType>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.WebServiceURI + "/Personne/ListCapteur";
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
        internal static async Task<string> Save(Capteur item)
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = "http://51.77.137.170:8080/equipes";
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            if (item != null)
            {
                sb.Append(@"{""Id"" : """ + item.Id_Device + @""",");
                sb.Append(@"""CapteurTypeId"" : """ + item.CapteurTypeId + @""",");
                sb.Append(@"""ValeurTypeId"" : """ + item.ValueTypeId + @""",");
                sb.Append(@"""BoxId"" : """ + item.BoxId);

                if (item.seuil_min != 0 && item.seuil_max != 0)
                {
                    sb.Append(@""",");
                    sb.Append(@"""SeuilMin"" : """ + item.seuil_min + @""",");
                    sb.Append(@"""SeuiMax"" : """ + item.seuil_max + @"""}");
                }
                else
                {
                    sb.Append(@"""}");
                }
                string jsonData = sb.ToString();
                //string json = JsonConvert.SerializeObject(item); A utiliser que si envoie d'une liste complète dès le départ.
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    var response = await httpClient.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "ErreurStatusCode";
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return "ErreurTryCatch";
                }
            }
            else
            {
                Debug.WriteLine("Erreur dans Save Capteur");
                return "ErreurCapteurNull";
            }
        }
    }
}


