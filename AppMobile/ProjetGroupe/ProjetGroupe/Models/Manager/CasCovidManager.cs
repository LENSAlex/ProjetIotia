using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.Models.Manager
{
    /// <summary>
    /// Classe CasCovid Manager
    /// </summary>
    internal static class CasCovidManager
    {
        /// <summary>
        /// Méthode prenant un CasCovid en paramètre contenant les informations à POST vers l'API REST
        /// </summary>
        /// <param name="cas"></param>
        /// <returns>"OK" si code réponse = 200 sinon erreur</returns>
        internal static async Task<string> SendAlert(CasCovid cas)
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = Config.URIAlerte + "/Covid/" + cas.PersonneId;
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            if (cas != null)
            {
                sb.Append(@"{""id_personne"" : " + cas.PersonneId);
                sb.Append("}");

                string jsonData = sb.ToString();
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
                        return "ErreurInsert";
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
                return "ErreurNull";
            }
        }
        /// <summary>
        /// Méthode faisant un GET vers l'API REST
        /// </summary>
        /// <returns>Une liste de CasCovid ou null si erreur</returns>
        internal static async Task<List<CasCovid>> ListCasCovid()
        {
            var httpClient = new HttpClient();
            List<CasCovid> list = new List<CasCovid>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URICovid + "/CasCovid";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<CasCovid>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }

        /// <summary>
        /// Méthode faisant un GET vers l'API REST
        /// </summary>
        /// <returns>Une liste de CasCovid par formation ou null si erreur</returns>
        internal static async Task<List<CasCovid>> ListCasCovidFormation()
        {
            var httpClient = new HttpClient();
            List<CasCovid> list = new List<CasCovid>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URICovid + "/Count/CasCovid/Formation";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<CasCovid>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        /// <summary>
        /// Méthode faisant un GET vers l'API REST
        /// </summary>
        /// <returns>Une liste de CasCovid par département ou null si erreur</returns>
        internal static async Task<List<CasCovid>> ListCasCovidDepartement()
        {
            var httpClient = new HttpClient();
            List<CasCovid> list = new List<CasCovid>();
            if (Device.RuntimePlatform == Device.Android)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            string WebAPIUrl = Config.URICovid + "/Count/CasCovid/Departement";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<CasCovid>>(content);
                    return list;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}