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
    /// <summary>
    /// ListeIOTDeviseModel est la class principale du back " ListeIOTDevise.cshtml.c" de la page web " ListeIOTDevise.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// </summary>
    public class ListeIOTDeviseModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Devise Méthode Get/Set de type IEnumerable IOTDevise qui me permet de charger tout les donner des box et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise> Devise { get; private set; }

        /// <summary>
        /// Capteur Méthode Get/Set de type IEnumerable ListeCapteur qui me permet de charger tout les donner des capteur et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<ListeCapteur> Capteur { get; private set; }

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public ListeIOTDeviseModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode   await LoadIOTDevise();  await LoadCapteur();
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
            await LoadIOTDevise();
            await LoadCapteur();
        }

        /// <summary>
        /// LoadIOTDevise est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Devise .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// LoadCapteur est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Capteur .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// OnGetRecherche et une methode qui permet de faire une recherche sur la liste . elle modifi donc la liste ù
        /// en fonction de ce qu'il a dans les parametre pour cela je charge la methode Branches par une requette Get 
        /// cette méthode et activer par de l'ajax dans le front qui recuper le text inscrit dans input et vas charger la 
        /// list . la nouvelle list sera utiliser ensuit dans le partial _PartialListIOT
        /// </summary>
        /// <param name="nomBox">la rechere choisi dans input</param>
        /// <returns>elle retune le resulta dans le partial PartialIOTDevise/_PartialListIOT</returns>
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
