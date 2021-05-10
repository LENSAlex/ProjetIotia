using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClasseE_Covid.LogAlerte;
using ClasseE_Covid;
using System.Net.Http;
using System.Text.Json;
//using System.Net.Http;
using Microsoft.AspNetCore.Http;
using ClasseE_Covid.Capteur;

namespace Smart_ECovid_IUT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.LogAlerte.LogAlerte> Branches { get; private set; } //GitHubBranch et une class
        public IEnumerable<Co2> ListCo2 { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            
          //  HttpContext.Session.SetInt32("UtilisateurId", 1);
           // HttpContext.Session.SetString("Token", "test");

            string login = Login.Current(HttpContext);
            if (login == null)
            {
                Response.Redirect("/login");
            }

            await Load();
            await LoadCO2();
        }

        public async Task Load()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3002/Covid/Count/CasCovid/Departement"); // /Covid/CasCovid
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.LogAlerte.LogAlerte>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<ClasseE_Covid.LogAlerte.LogAlerte>();
            }
        }
        public async Task LoadCO2()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://webservice.lensalex.fr:3005/InfraProd/List/Historique/CO2");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                ListCo2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<Co2>>(responseStream); // remplie la class GitHubBranch 
                
            }
            else
            {
                GetBranchesError = true;
                ListCo2 = Array.Empty<Co2>();
            }
        }
    }
}
