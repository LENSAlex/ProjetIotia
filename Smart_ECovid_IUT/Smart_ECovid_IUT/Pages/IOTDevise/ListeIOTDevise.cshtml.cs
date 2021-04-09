using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.IOTDevise;
using System.Text.Json;

namespace Smart_ECovid_IUT.Pages.IOTDevise
{
    public class ListeIOTDeviseModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise> Branches { get; private set; } //IOTDevise et une class
        public IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise> Branches2 { get; private set; } //IOTDevise et une class

        public bool GetBranchesError { get; private set; }

        public ListeIOTDeviseModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Personne/Box/Info"); 
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<ClasseE_Covid.IOTDevise.IOTDevise>();
            }

            var request2 = new HttpRequestMessage(HttpMethod.Get,
          "http://51.75.125.121:3001/Personne/ListDevice");
            request2.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request2.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client2 = _clientFactory.CreateClient();

            var response2 = await client.SendAsync(request2); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response2.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Branches2 = Array.Empty<ClasseE_Covid.IOTDevise.IOTDevise>();
            }
        }
    }
}
