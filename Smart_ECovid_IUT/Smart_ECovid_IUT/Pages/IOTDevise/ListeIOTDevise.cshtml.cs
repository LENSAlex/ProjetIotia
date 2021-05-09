using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.IOTDevise;
using System.Text.Json;
using ClasseE_Covid;

namespace Smart_ECovid_IUT.Pages.IOTDevise
{
    public class ListeIOTDeviseModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise> Devise { get; private set; } //IOTDevise et une class
        public IEnumerable<ListeCapteur> Capteur { get; private set; } //IOTDevise et une class

        public bool GetBranchesError { get; private set; }

        public ListeIOTDeviseModel(IHttpClientFactory clientFactory)
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
            await LoadIOTDevise();
            await LoadCapteur();
        }
        public async Task LoadIOTDevise()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/Box/Info");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Devise = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Devise = Array.Empty<ClasseE_Covid.IOTDevise.IOTDevise>();
            }
        }

        public async Task LoadCapteur()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/ListCapteur");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Capteur = await JsonSerializer.DeserializeAsync
                <IEnumerable<ListeCapteur>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Capteur = Array.Empty<ListeCapteur>();
            }
        }
        public async Task<IActionResult> OnGetRecherche(string nomBox)
        {
            await LoadIOTDevise();
            await LoadCapteur();
            //var movies = from m in _context.Movie
            //             select m;

            if (!String.IsNullOrEmpty(nomBox))
            {
                Devise = Devise.Where(s => s.NomBox.Contains(nomBox));
            }
            return Partial("PartialIOTDevise/_PartialListIOT", this);
        }
    }
}
