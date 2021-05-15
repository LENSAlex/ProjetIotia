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
using ClasseE_Covid.Campus;


namespace Smart_ECovid_IUT.Pages
{
    /// <summary>
    /// IndexModel est la class principale du back " Index.cshtml.c" de la page web " Index.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Branches Méthode Get/Set de type IEnumerable LogAlerte qui me permet de charger tout les donner des cas covid et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<ClasseE_Covid.LogAlerte.LogAlerte> Branches { get; private set; }

        /// <summary>
        /// ListCo2 Méthode Get/Set de type IEnumerable Co2 qui me permet de charger tout les donner du Co2 et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Co2> ListCo2 { get; private set; }

        /// <summary>
        /// cntCo2 Méthode Get/Set de type IEnumerable IEnumerable qui me permet de charger tout les donner du Co2 et fait un count sur celle qui on une valeut supp a 80 
        /// et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Co2> cntCo2 { get; private set; }

        /// <summary>
        /// ListTemp Méthode Get/Set de type IEnumerable Temperature qui me permet de charger tout les donner des Temperature , fait un count  et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Temperature> ListTemp { get; private set; }

        /// <summary>
        /// ListOccu Méthode Get/Set de type IEnumerable OccupationBatiment qui me permet de charger tout les donner des Occupation Batiment , fait un count et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<OccupationBatiment> ListOccu { get; private set; }


        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode   await Load();  await LoadCO2();  await LoadOccupation();  await LoadTemp();
        /// ces méthode on un await car elle attende une reponce de API.
        /// Puis que c'est la permier méthode utiliser il y a une verification si la personne qui veut rentrait dans 
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

            await Load();
            await LoadCO2();
            await LoadOccupation();
            await LoadTemp();
        }

        /// <summary>
        /// Load est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Branches .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// LoadCO2 est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode ListCo2 .
        /// il y a une verification si la requtte c'est bien fait.
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
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                ListCo2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<Co2>>(responseStream); // remplie la class GitHubBranch 
                cntCo2 = ListCo2.Where(s => s.ValeurCo2 > 80);
            }
            else
            {
                GetBranchesError = true;
                ListCo2 = Array.Empty<Co2>();
            }
        }

        /// <summary>
        /// LoadTemp est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode ListTemp .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadTemp()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://webservice.lensalex.fr:3005/InfraProd/List/Historique/Temp");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                ListTemp = await JsonSerializer.DeserializeAsync
                <IEnumerable<Temperature>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
                ListTemp = Array.Empty<Temperature>();
            }
        }

        /// <summary>
        /// LoadOccupation est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode ListOccu .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadOccupation()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://webservice.lensalex.fr:3001/Usager/List/TauxOccupation/Batiment");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                ListOccu = await JsonSerializer.DeserializeAsync
                <IEnumerable<OccupationBatiment>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
                ListOccu = Array.Empty<OccupationBatiment>();
            }
        }
    }
}
