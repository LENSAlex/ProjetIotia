using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClasseE_Covid.LogAlerte;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http;



namespace Smart_ECovid_IUT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.LogAlerte.LogAlerte> Branches { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Covid/Count/CasCovid/Departement"); // /Covid/CasCovid
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
    }
}
