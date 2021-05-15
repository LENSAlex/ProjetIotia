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
    /// <summary>
    /// ListeCampusModel est la class principale du back "ListeCampus.cshtml.c" de la page web "ListeCampus.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// il posible aussi de faire une modification ou une suppression de batiment front
    /// </summary>
    public class ListeCampusModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Branches Méthode Get/Set de type IEnumerable Campus qui me permet de charger tout les donner des batiement et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<ClasseE_Covid.Campus.Campus> Branches { get; private set; }

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }


        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public ListeCampusModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode await LoadBati();
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
            await LoadBati();
        }

        /// <summary>
        /// LoadBati est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Branches .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadBati()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3000/Infrastructure/ListBatiment");
            request.Headers.Add("Accept", "application/json");  
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }

        /// <summary>
        /// OnGetRecherche et une methode qui permet de faire une recherche sur la liste . elle modifi donc la liste ù
        /// en fonction de ce qu'il a dans les parametre pour cela je charge la methode Branches par une requette Get 
        /// cette méthode et activer par de l'ajax dans le front qui recuper le text inscrit dans input et vas charger la 
        /// list . la nouvelle list sera utiliser ensuit dans le partial _PatialListCampus
        /// </summary>
        /// <param name="seach">la rechere choisi dans input</param>
        /// <returns>elle retune le resulta dans le partial PartialIOTDevise/_PatialListCampus</returns>
        public async Task<IActionResult> OnGetRecherche(string seach)
        {
            await LoadBati();
            //var movies = from m in _context.Movie
            //             select m;

            if (!String.IsNullOrEmpty(seach))
            {
                Branches = Branches.Where(s => s.NomBatimen.Contains(seach));
            }
            return Partial("PartialIOTDevise/_PatialListCampus", this);
        }
    }
}
