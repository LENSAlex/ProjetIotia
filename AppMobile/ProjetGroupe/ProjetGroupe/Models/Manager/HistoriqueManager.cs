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
    /// Classe Manager Historique des valeurs des capteurs
    /// </summary>
    internal static class HistoriqueManager
    {
        /// <summary>
        /// Fonction qui fait une requête GET vers l'API REST
        /// </summary>
        /// <returns>Une liste d'Historique si code = 200 sinon erreur</returns>
        internal static async Task<List<Historique>> ListHistorique()
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URIInfraProd + "/List/Historique";
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
        /// <summary>
        /// Fonction qui donne la ligne la plus récente de l'historique du capteur choisit
        /// GET vers l'API REST
        /// </summary>
        /// <param name="CapteurId">Id du capteur</param>
        /// <returns>Une liste d'Historique (d'une ligne) si code = 200 sinon erreur</returns>
        internal static async Task<List<Historique>> ListValeurLast(int CapteurId)
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URIInfraProd + "/ValeurSpecifique/Last/" + CapteurId;
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
        /// <summary>
        /// Fonction qui donne les lignes les valeurs moyennes du capteur choisit
        /// GET vers l'API REST
        /// </summary>
        /// <param name="CapteurId">Id du capteur</param>
        /// <returns>Une liste d'Historique si code = 200 sinon erreur</returns>
        internal static async Task<List<Historique>> ListValeurMoyenne(int CapteurId)
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URIInfraProd + "/ValeurSpecifique/Moyenne/" + CapteurId;
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
        /// <summary>
        /// Fonction qui donne les données du capteur choisit via son Id (Identique a moyenne mais nomage changé pour plus de perception dans le code)
        /// GET vers l'API REST
        /// </summary>
        /// <param name="CapteurId">Id du capteur</param>
        /// <returns>Une liste d'Historique si code = 200 sinon erreur</returns>
        internal static async Task<List<Historique>> Load(int CapteurId)
        {
            var httpClient = new HttpClient();
            List<Historique> list = new List<Historique>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URIInfraProd + "/ValeurSpecifique/Moyenne/" + CapteurId;
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
