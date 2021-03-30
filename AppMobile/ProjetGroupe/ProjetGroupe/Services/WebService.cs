using Newtonsoft.Json;
using ProjetGroupe.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ProjetGroupe.ViewModels.AboutViewModel;
using static ProjetGroupe.Views.AboutPage;

namespace ProjetGroupe.Services
{
    public class WebService
    {

    }
    public static class Constants
    {
        public const string WebRequest = "http://51.75.125.121:8080/testlolo";
    }
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();

            if (Device.RuntimePlatform == Device.Android)
            {
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        //public async Task<WebRequestProperty> GetRepositoriesAsync(string uri)
        //{
        //    WebRequestProperty repositories = null;
        //    try
        //    {
        //        HttpResponseMessage response = await _client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            repositories = JsonConvert.DeserializeObject<WebRequestProperty>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }

        //    return repositories;
        //}
    }

}


