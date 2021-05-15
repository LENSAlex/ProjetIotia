using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid;
using ClasseE_Covid.Capteur;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart_ECovid_IUT.Pages.LogAlerte
{
    /// <summary>
    /// AfficheLogAlerteModel est la class principale du back " AfficheLogAlerte.cshtml.c" de la page web " AfficheLogAlerte.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// </summary>
    public class AfficheLogAlerteModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Branches M�thode Get/Set de type IEnumerable LogAlerte qui me permet de charger tout les donner des cas covid et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<ClasseE_Covid.LogAlerte.LogAlerte> Branches { get; private set; }

        /// <summary>
        /// ListCo2 M�thode Get/Set de type IEnumerable Co2 qui me permet de charger tout les donner du Co2 et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Co2> ListCo2 { get; private set; }

        /// <summary>
        /// GetBranchesError M�thode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public AfficheLogAlerteModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet M�thode qui est utiliser des lors de l'ouverture de la page. c'est la premier m�hode a etre utiliser 
        /// elle est de type  async Task pour utiliser les m�htode   await LoadCasCovid(); await LoadCO2();
        /// ces m�thode on un await car elle attende une reponce de API.
        /// Puis que c'est la permier m�thode utiliser il y a une verification si la personne qui veut rentrait dans 
        /// cette page c'est bien login alor elle pourrat voir la page sionn elle sera rediriger vers la page de login
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            string login = Login.Current(HttpContext);
            if (login == null)
            {
                Response.Redirect("/login");
            }
            await LoadCasCovid();
            await LoadCO2();
        }

        /// <summary>
        /// LoadCasCovid est une m�thode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la m�thode Branches .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// LoadCO2 est une m�thode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la m�thode ListCo2 .
        /// il y a une verification si la requtte c'est bien fait. 
        /// j'utilise la methode Where sur ma listre pour filtrer les valleur et mettre celle qui son au dessus de 80
        /// </summary>
        /// <returns></returns>
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
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                ListCo2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<Co2>>(responseStream); // remplie la class GitHubBranch 
                ListCo2 = ListCo2.Where(s => s.ValeurCo2 > 80);
            }
            else
            {
                GetBranchesError = true;
                ListCo2 = Array.Empty<Co2>();
            }
        }
    }
}
