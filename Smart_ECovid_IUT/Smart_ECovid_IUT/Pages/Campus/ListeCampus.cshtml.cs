using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Campus;
using System.Text.Json;

namespace Smart_ECovid_IUT.Pages.Campus
{
    public class ListeCampusModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.Campus.Campus> Branches { get; private set; } //GitHubBranch et une class
        public IEnumerable<ClasseE_Covid.Campus.Campus> Branches2 { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public ListeCampusModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Batiment/CountInfo/Campus");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }

            var request2 = new HttpRequestMessage(HttpMethod.Get,
          "http://51.75.125.121:3001/Batiment/ListBatiment");
            request2.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request2.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client2 = _clientFactory.CreateClient();

            var response2 = await client.SendAsync(request2); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response2.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Branches2 = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }
    }
}
