using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Campus;
using System.Text.Json;
using ClasseE_Covid;

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
            string login = Login.Current(HttpContext);
            if (login == null)
            {
                Response.Redirect("/login");
            }
            // await LoadCampus();
            await LoadBati();
        }

        public async Task LoadCampus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3000/Batiment/CountInfo/Campus");
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
        }

        public async Task LoadBati()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3000/Infrastructure/ListBatiment");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Branches2 = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }
        public async Task<IActionResult> OnGetRecherche(string seach)
        {
            await LoadBati();
            //var movies = from m in _context.Movie
            //             select m;

            if (!String.IsNullOrEmpty(seach))
            {
                Branches2 = Branches2.Where(s => s.NomBatimen.Contains(seach));
            }
            return Partial("PartialIOTDevise/_PatialListCampus", this);
        }
    }
}
