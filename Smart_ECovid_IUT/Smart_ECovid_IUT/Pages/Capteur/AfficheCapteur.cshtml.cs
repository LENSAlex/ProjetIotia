using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Capteur;
using System.Text.Json;

namespace Smart_ECovid_IUT.Pages.Capteur
{
    public class AfficheCapteurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<Temperature> Temperature { get; private set; } 
        public IEnumerable<Co2> Co2 { get; private set; } 
        public IEnumerable<Energie> Energie { get; private set; } 
        public bool GetBranchesError { get; private set; }

        public AfficheCapteurModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            await LoadCo2();
            await LoadTemperatuer();
            await LoadEnergie();
        }
        public async Task LoadEnergie()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Capteur/List/Historique/Energie");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Energie = await JsonSerializer.DeserializeAsync
                <IEnumerable<Energie>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Energie = Array.Empty<Energie>();
            }
        }

        public async Task LoadTemperatuer()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Capteur/List/Historique/Temp");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Temperature = await JsonSerializer.DeserializeAsync
                <IEnumerable<Temperature>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Temperature = Array.Empty<Temperature>();
            }
        }

        public async Task LoadCo2()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Capteur/List/Historique/CO2");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Co2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<Co2>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Co2 = Array.Empty<Co2>();
            }
        }
    }

}
