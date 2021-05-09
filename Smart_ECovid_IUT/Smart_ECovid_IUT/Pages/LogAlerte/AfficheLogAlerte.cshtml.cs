using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart_ECovid_IUT.Pages.LogAlerte
{
    public class AfficheLogAlerteModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.LogAlerte.LogAlerte> Branches { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public AfficheLogAlerteModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            string login = Login.Current(HttpContext);
            if (login == null)
            {
                Response.Redirect("/login");
            }
            await LoadCasCovid();
        }
        public async Task LoadCasCovid()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://webservice.lensalex.fr:3002/Covid/CasCovid");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
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
