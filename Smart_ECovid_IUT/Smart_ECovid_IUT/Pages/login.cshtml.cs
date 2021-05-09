using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid;
using Microsoft.AspNetCore.Http;

namespace Smart_ECovid_IUT.Pages
{
    public class loginModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public loginModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public void OnGet()
        {

        }

        public async Task OnPostLogin()
        {
            Login.NomLogin = Request.Form["nom"];
            Login.Mdp = Request.Form["mdp"];

            await LoadToken();
        }

        public async Task LoadToken()
        {
           // Login login = new Login();
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://webservice.lensalex.fr:3004/InfraAdmin/login/"+ Login.NomLogin + "/" + Login.Mdp);
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Login.Token = await JsonSerializer.DeserializeAsync<string>(responseStream); // remplie la class GitHubBranch 
                HttpContext.Session.SetInt32("UtilisateurId", 1);
                HttpContext.Session.SetString("Token", Login.Token);
                HttpContext.Session.SetString("Nom", Login.NomLogin);

                Response.Redirect("/Index");
            }
            else
            {
                //GetBranchesError = true;
                //Login.Token = Array.Empty<string>();
            }
        }
    }
}
