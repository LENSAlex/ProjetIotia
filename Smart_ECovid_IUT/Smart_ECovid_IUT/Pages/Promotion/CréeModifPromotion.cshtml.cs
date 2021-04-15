using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart_ECovid_IUT.Pages.Promotion
{
    public class CréeModifPromotionModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<GitHubBranch> Branches { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public CréeModifPromotionModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
           var request = new HttpRequestMessage(HttpMethod.Get,
          "http://51.75.125.121:3001/Personne/ListProf");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
               // Branches = await JsonSerializer.DeserializeAsync
                //<IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
               // Branches = Array.Empty<ClasseE_Covid.Utilisateur.Utilisateur>();
            }
        }
        internal static async Task<string> Save(GitHubBranch item)
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = "http://51.75.125.121:3001/Personne/ListPromo";
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();
            if (item != null)
            {
                sb.Append(@"{""Id"" : " + item.Id + ",");
                sb.Append(@"""name"" : """ + item.Name + @""",");
                sb.Append(@"""disponible"" : " + item.Disponible );
                sb.Append(@"""}");

                string jsonData = sb.ToString();
                //string json = JsonConvert.SerializeObject(item); A utiliser que si envoie d'une liste complète dès le départ.
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    var response = await httpClient.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "ErreurStatusCode";
                    }
                }
                catch (Exception e)
                {
                   // Debug.WriteLine(e.Message);
                    return "ErreurTryCatch";
                }
            }
            else
            {
               // Debug.WriteLine("Erreur dans Save Capteur");
                return "ErreurCapteurNull";
            }
        }

        public void OnPostEnvoieDonne()
        {
            GitHubBranch gitHubBranch = new GitHubBranch();

            gitHubBranch.Id = Convert.ToInt32(Request.Form["id"]);
            gitHubBranch.Name = Request.Form["nom"];

            if (Request.Form["duree"] == "1")
                gitHubBranch.Disponible = true;
            else
                gitHubBranch.Disponible = false;

            GetDataAsync(gitHubBranch);
        }
        public async Task GetDataAsync(GitHubBranch gitHubBranch)
        {
            await Save(gitHubBranch);

            Response.Redirect("/Promotion/ListePromotion");
        }
    }
}

