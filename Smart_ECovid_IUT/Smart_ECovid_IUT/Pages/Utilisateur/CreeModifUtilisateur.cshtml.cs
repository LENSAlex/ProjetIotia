using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Utilisateur;
using ClasseE_Covid.Promotion;
using System.Text;
using System.Text.Json;

namespace Smart_ECovid_IUT.Pages.Utilisateur
{
    public class CreeModifUtilisateurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<Niveau> DDNiveau { get; private set; } 
        public IEnumerable<PromotionClass> DDPromotion { get; private set; } 

        public bool GetBranchesError { get; private set; }

        public CreeModifUtilisateurModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGet()
        {
            await LoadDDNiveau();
            await LoadFormation();
        }

        public async Task LoadDDNiveau()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
          "http://51.75.125.121:3001/Personne/ListTypePersonne");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDNiveau = await JsonSerializer.DeserializeAsync
                <IEnumerable<Niveau>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDNiveau = Array.Empty<Niveau>();
            }
        }
        public async Task LoadFormation()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
         "http://51.75.125.121:3001/Personne/ListPromo");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDPromotion = await JsonSerializer.DeserializeAsync
                <IEnumerable<PromotionClass>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
                DDPromotion = Array.Empty<PromotionClass>();
            }
        }

        internal async Task<string> Save(ClasseE_Covid.Utilisateur.Utilisateur item)
        {
            var httpClient = new HttpClient();
            // / Personne / Add / NumRef / IdPersType / Password / Email / Tel / Sexe / Nom / Prenom / Birth / IdPromo
            string WebAPIUrl = "http://51.75.125.121:3001/Personne/Add/"+ item.NumRef + "/"+ item.IdPersType + "/"+ item.Pwd + "/" + item.Email + "/"+ item.Telephone + "/"+ item.Sexe + "/"+ item.Nom + "/"+ item.Prenom + "/"+ item.Anniv + "/"+ item.Promotion;
            // string WebAPIUrl = "http://51.75.125.121:3001/Personne/Add/Test/"+ item.Nom + "/"+ item.Prenom;
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();
            if (item != null)
            {
                sb.Append(@"{""NumRef"" : """ + item.NumRef + @""",");
                sb.Append(@"""IdPersType"" : " + item.IdPersType + ",");
                sb.Append(@"""Email"" : """ + item.Email + @""",");
                sb.Append(@"""Tel"" : """ + item.Telephone + @""",");
                sb.Append(@"""Sexe"" : """ + item.Sexe + @""",");
                sb.Append(@"""Nom"" : """ + item.Nom + @""",");
                sb.Append(@"""Prenom"" : """ + item.Prenom + @""",");
                sb.Append(@"""Birth"" : """ + item.Anniv + @""",");
                sb.Append(@"""IdPromo"" : " + item.Promotion);
                sb.Append("}");

                string jsonData = sb.ToString();
                await LoadFormation();
                await LoadDDNiveau();
                //string json = JsonConvert.SerializeObject(item); // A utiliser que si envoie d'une liste complète dès le départ.
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    var response = await httpClient.PostAsync(uri, content);
                    //var response = await httpClient.PostAsync(uri, formData).Result;
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
            ClasseE_Covid.Utilisateur.Utilisateur utilisateur = new ClasseE_Covid.Utilisateur.Utilisateur();

            utilisateur.Prenom =Request.Form["prenom"];
            utilisateur.Nom = Request.Form["nom"];
            utilisateur.NumRef = Request.Form["num_ref"];
            utilisateur.IdPersType = Convert.ToInt32( Request.Form["niveau"]);
            utilisateur.Pwd = Request.Form["pwd"];
            string pwd  = Request.Form["pwd2"];
            utilisateur.Email = Request.Form["email"];
            utilisateur.Telephone = Request.Form["tel"];
            utilisateur.Sexe = Request.Form["sexe"];
            utilisateur.Anniv = Request.Form["anniv"];
            utilisateur.Promotion = Convert.ToInt32(Request.Form["formation"]);

            GetDataAsync(utilisateur);
        }
        public async Task GetDataAsync(ClasseE_Covid.Utilisateur.Utilisateur utilisateur)
        {
            await Save(utilisateur);
            Response.Redirect("/Utilisateur/ListeUtilisateur");
        }
    }
}
