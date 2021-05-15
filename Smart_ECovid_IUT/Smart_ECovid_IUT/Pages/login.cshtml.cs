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
    /// <summary>
    /// loginModel est la class principale du back " login.cshtml.c" de la page web " login.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// </summary>
    public class loginModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public loginModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// méthode non utiliser
        /// </summary>
        public void OnGet()
        {
        }


        /// <summary>
        /// OnPostLogin est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode LoadToken elle est de type  async Task pour utiliser cette méthode
        /// </summary>
        public async Task OnPostLogin()
        {
            Login.NomLogin = Request.Form["nom"];
            Login.Mdp = Request.Form["mdp"];

            await LoadToken();
        }

        /// <summary>
        /// LoadToken est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get avec des parmetre le nom et mpd sur l'API est donnée le token d'identification .
        /// les donner qui on etait ecrit et le tokent sont sauvegarder par le  HttpContext.Session ou la class Login qui est static
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadToken()
        {
           // Login login = new Login();
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://webservice.lensalex.fr:3004/InfraAdmin/login/"+ Login.NomLogin + "/" + Login.Mdp);
            request.Headers.Add("Accept", "application/json");  
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");  

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
