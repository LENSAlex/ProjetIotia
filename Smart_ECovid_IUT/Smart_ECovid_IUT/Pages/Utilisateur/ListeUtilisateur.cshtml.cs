using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Utilisateur;
using System.Text.Json;
using System.Text;
using ClasseE_Covid;

namespace Smart_ECovid_IUT.Pages.Utilisateur
{
    /// <summary>
    /// ListeUtilisateurModel est la class principale du back "ListeUtilisateur.cshtml.c" de la page web "ListeUtilisateur.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// il posible aussi de faire une modification ou une suppression de batiment front
    /// </summary>
    public class ListeUtilisateurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Branches Méthode Get/Set de type IEnumerable Utilisateur qui me permet de charger tout les donner des Promotion et Fromation et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur> Branches { get; private set; } //GitHubBranch et une class

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }


        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public ListeUtilisateurModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode await Load();
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
          "http://51.75.125.121:3007/Personne/ListPersonne");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce DeleteAsync

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<ClasseE_Covid.Utilisateur.Utilisateur>();
            }
        }


        /// <summary>
        /// OnGetDeleteUser est une méthode qui permet de faire une requette de delete sur l'API. cette requette suprime un utilisateur
        /// La méthode est acitonner dans le front grasse a de l'Ajax avec l'id de l'apromotion que l'ont veus supp .la requette ce fait dans url est je 
        /// met id a la fin de url.le OnGet devent le nom de la méthode est obligatoire pour appeler cette methode depuis l'Ajax. Attention le nom du 
        /// parametre doit etre identique.
        /// </summary>
        /// <param name="id">id de l'utilisateur que l'on veut supriment</param>
        public async void OnGetDeleteUser(int id)
        {
            var httpClient = new HttpClient();
            // / Personne / Add / NumRef / IdPersType / Password / Email / Tel / Sexe / Nom / Prenom / Birth / IdPromo
            string WebAPIUrl = "http://51.75.125.121:3007/Personne/Delete/"+Convert.ToString(id);
            Uri uri = new Uri(WebAPIUrl);

            var response = await httpClient.DeleteAsync(uri);
            
            await Load();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("ErreurStatusCode");
                }
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);
                Console.WriteLine("ErreurTryCatch");
            }
        }


        /// <summary>
        /// OnGetRecherche et une methode qui permet de faire une recherche sur la liste . elle modifi donc la liste ù
        /// en fonction de ce qu'il a dans les parametre pour cela je charge la methode Branches par une requette Get 
        /// cette méthode et activer par de l'ajax dans le front qui recuper le text inscrit dans input et vas charger la 
        /// list . la nouvelle list sera utiliser ensuit dans le partial _PatialListUtilisateur
        /// </summary>
        /// <param name="seach">la rechere choisi dans input</param>
        /// <returns>elle retune le resulta dans le partial PartialIOTDevise/_PatialListUtilisateu</returns>
        public async Task<IActionResult> OnGetRecherche(string seach)
        {
            await Load();
            //var movies = from m in _context.Movie
            //             select m;

            if (!String.IsNullOrEmpty(seach))
            {
                Branches = Branches.Where(s => s.Nom.Contains(seach));
            }
            return Partial("PartialIOTDevise/_PatialListUtilisateur", this);
        }
    }
}
