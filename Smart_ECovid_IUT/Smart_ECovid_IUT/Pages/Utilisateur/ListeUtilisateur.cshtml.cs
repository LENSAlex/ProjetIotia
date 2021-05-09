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
    public class ListeUtilisateurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur> Branches { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public ListeUtilisateurModel(IHttpClientFactory clientFactory)
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
            await Load();
        }

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
