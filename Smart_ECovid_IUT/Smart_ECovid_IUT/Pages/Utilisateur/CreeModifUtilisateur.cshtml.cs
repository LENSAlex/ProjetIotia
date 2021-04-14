using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Utilisateur;
using System.Text;

namespace Smart_ECovid_IUT.Pages.Utilisateur
{
    public class CreeModifUtilisateurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur> Branches { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public CreeModifUtilisateurModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public void OnGet()
        {

        }
        internal static async Task<string> Save(ClasseE_Covid.Utilisateur.Utilisateur item)
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

                //List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();

                //pairs.Add(new KeyValuePair<string, string>("NumRef", item.NumRef));
                //pairs.Add(new KeyValuePair<string, string>("IdPersType", item.Niveau));
                //pairs.Add(new KeyValuePair<string, string>("Password", item.Pwd));
                //pairs.Add(new KeyValuePair<string, string>("Tel", item.Telephone));
                //pairs.Add(new KeyValuePair<string, string>("Email", item.Email));
                //pairs.Add(new KeyValuePair<string, string>("Sexe", item.Sexe));
                //pairs.Add(new KeyValuePair<string, string>("Nom", item.Nom));
                //pairs.Add(new KeyValuePair<string, string>("Prenom", item.Prenom));
                //pairs.Add(new KeyValuePair<string, DateTime>("Birth", item.Anniv));
                //pairs.Add(new KeyValuePair<string, string>("IdPromo", item.Promotion));

                //HttpContent stringContent1 = new StringContent("NumRef");
                //HttpContent stringContent2 = new StringContent("IdPersType");
                //HttpContent stringContent3 = new StringContent("Password");
                //HttpContent stringContent4 = new StringContent("Tel");
                //HttpContent stringContent5 = new StringContent("Email");
                //HttpContent stringContent6 = new StringContent("Sexe");
                //HttpContent stringContent7 = new StringContent("Nom");
                //HttpContent stringContent8 = new StringContent("Prenom");
                //HttpContent stringContent9 = new StringContent("Birth");
                //HttpContent stringContent10 = new StringContent("IdPromo");

                //var formData = new MultipartFormDataContent();

                //formData.Add(stringContent1, item.NumRef);
                //formData.Add(stringContent2, Convert.ToString(item.IdPersType));
                //formData.Add(stringContent3,Convert.ToString(item.IdPersType));
                //formData.Add(stringContent4, item.Pwd);
                //formData.Add(stringContent5, item.Telephone);
                //formData.Add(stringContent6, item.Email);
                //formData.Add(stringContent7, item.Sexe);
                //formData.Add(stringContent8, item.Nom);
                //formData.Add(stringContent9, item.Prenom);
                //formData.Add(stringContent10, Convert.ToString(item.Anniv));
                //formData.Add(stringContent10, item.Promotion);


                sb.Append(@"{""NumRef"" : """ + item.NumRef + @""",");
                sb.Append(@"""IdPersType"" : " + item.IdPersType + ",");
                sb.Append(@"""Password"" : """ + item.Pwd + @""",");
                sb.Append(@"""Email"" : """ + item.Email + @""",");
                sb.Append(@"""Tel"" : """ + item.Telephone + @""",");
                sb.Append(@"""Sexe"" : """ + item.Sexe + @""",");
                sb.Append(@"""Nom"" : """ + item.Nom + @""",");
                sb.Append(@"""Prenom"" : """ + item.Prenom + @""",");
                sb.Append(@"""Birth"" : """ + item.Anniv + @""",");
                sb.Append(@"""IdPromo"" : " + item.Promotion);
                sb.Append("}");

                string jsonData = sb.ToString();
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
