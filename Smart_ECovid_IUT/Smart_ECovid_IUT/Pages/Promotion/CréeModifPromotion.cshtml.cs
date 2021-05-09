using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid.Utilisateur;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Promotion;
using ClasseE_Covid;
using System.Net.Http.Headers;

namespace Smart_ECovid_IUT.Pages.Promotion
{
    public class CréeModifPromotionModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public CréeModifPromotionModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IEnumerable<PromotionClass> ModifPromo { get; private set; }

        public IEnumerable<ClasseE_Covid.Campus.Campus> DDBat { get; private set; }
        //Prof prof;
        public IEnumerable<Prof> DDProf { get; private set; }
        public string Nom { get; set; }
        public int Annee { get; set; }

        public int Duree { get; set; }

        public string Département { get; set; }

        public int idDepartement { get; set; }
        public string NomProf { get; set; }

        public int idProf { get; set; }

        public async Task OnGet(int? id)
        {
            string login = Login.Current(HttpContext);
            if (login == null)
            {
                Response.Redirect("/login");
            }

            if (id.HasValue)
            {
                await LoadCampus(id);
            }
            else
            {
                await LoadDDProf();
                await LoadBati();
            }
            //  Prof.GetProf();
            //  DDProf = Prof._DDProf;
        }

        public async void OnPostEnvoieDonne()
        {
            Formation formation = new Formation();

            formation.IdDepartement = Convert.ToInt32(Request.Form["departement"]);
            formation.AnneePromotion = Convert.ToInt32(Request.Form["annee"]);
            formation.DureeFormation = Convert.ToInt32(Request.Form["duree"]);
            formation.NomFormation = Request.Form["nom"];
            formation.IdProfesseurPromotion = Convert.ToInt32(Request.Form["prof"]);

            await Save(formation);

        }

        //internal async Task<string> Save(Formation formation)
        //{
        //    var httpClient = new HttpClient();
        //    // / Personne / Add / NumRef / IdPersType / Password / Email / Tel / Sexe / Nom / Prenom / Birth / IdPromo
        //    string WebAPIUrl = "/Personne/Modifs/Formation/" + formation.IdDepartement + "/" + formation.NomFormation + "/" + formation.DureeFormation + "/" + formation.AnneePromotion;
        //    Uri uri = new Uri(WebAPIUrl);
        //    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        //    StringBuilder sb = new StringBuilder();
        //    if (formation != null)
        //    {
        //        sb.Append(@"{""IdDepartement"" : " + formation.IdDepartement + ",");
        //        sb.Append(@"""NomFormation"" : """ + formation.NomFormation + @""",");
        //        sb.Append(@"""Email"" : " + formation.DureeFormation + ",");
        //        sb.Append(@"""AnneePromotion"" : """ + formation.AnneePromotion + @""",");
        //        //sb.Append(@"""Sexe"" : """ + item.Sexe + @""",");
        //        sb.Append("}");

        //        string jsonData = sb.ToString();
        //        // await LoadFormation();
        //        // await LoadDDNiveau();
        //        //string json = JsonConvert.SerializeObject(item); // A utiliser que si envoie d'une liste complète dès le départ.
        //        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        try
        //        {
        //            var response = await httpClient.PutAsync(uri, content);
        //            //var response = await httpClient.PostAsync(uri, formData).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return "Ok";
        //            }
        //            else
        //            {
        //                return "ErreurStatusCode";
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            // Debug.WriteLine(e.Message);
        //            return "ErreurTryCatch";
        //        }
        //    }
        //    else
        //    {
        //        // Debug.WriteLine("Erreur dans Save Capteur");
        //        return "ErreurCapteurNull";
        //    }
        //}

        public async Task LoadCampus(int? id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3000/Covid/Count/CasCovid/Formation/" + Convert.ToString(id));
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                ModifPromo = await JsonSerializer.DeserializeAsync
                <IEnumerable<PromotionClass>>(responseStream); // remplie la class Campus 

                foreach (PromotionClass promotion in ModifPromo)
                {
                    Nom = promotion.Nom;
                    Annee = promotion.Annee;
                    Duree = promotion.Duree;
                    //Département = promotion.Departemnt;
                    //idDepartement = promotion.IdDepartemnt;
                    //NomProf = promotion.nomProf;
                    //idProf = promotion.IdProf;
                }
            }
            else
            {
                // GetBranchesError = true;
                ModifPromo = Array.Empty<PromotionClass>();
            }
        }
        internal async Task<string> Save(Formation item)
        {
            string WebAPIUrl = "";
            var httpClient = new HttpClient();
            if (ModifPromo == null)
                WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Usager/Add/Promo/" + item.IdDepartement + "/" + item.NomFormation + "/" + item.DureeFormation + "/" + item.AnneePromotion + "/" + item.IdProfesseurPromotion;
            // WebAPIUrl = "http://51.75.125.121:3007/Personne/Add/Promo/" + item.IdDepartement + "/" + item.NomFormation + "/" + item.DureeFormation + "/" + item.AnneePromotion + "/" + item.IdProfesseurPromotion;
            else
                WebAPIUrl = "http://51.75.125.121:3007/Personne/Modifs/Formation/" + item.IdDepartement + "/" + item.NomFormation + "/" + item.DureeFormation + "/" + item.AnneePromotion;

            StringBuilder sb = new StringBuilder();
            if (item != null)
            {
                sb.Append(@"{""IdDepartement"" : " + item.IdDepartement + ",");
                sb.Append(@"""NomFormation"" : """ + item.NomFormation + @""",");
                sb.Append(@"""DureeFormation"" : " + item.DureeFormation + ",");
                sb.Append(@"""AnneePromotion"" : " + item.AnneePromotion + ",");
                sb.Append(@"""IdProfesseurPromotion"" : " + item.IdProfesseurPromotion);
                sb.Append(@"""}");

                string jsonData = sb.ToString();

                await LoadDDProf();

                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                    RequestUri = new Uri(WebAPIUrl)
                };

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Login.Token);

                try
                {
                    var response = await httpClient.SendAsync(requestMessage);
                    //if (ModifPromo != null)
                    // response = await httpClient.PutAsync(uri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Index();
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
        public static RedirectResult Index()
        {
            return new RedirectResult(url: "/Index", permanent: true,
                                      preserveMethod: true);
        }
        public async Task<IEnumerable<Prof>> LoadDDProf()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3001/Usager/ListProf");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = new HttpClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDProf = await JsonSerializer.DeserializeAsync
                <IEnumerable<Prof>>(responseStream2); // remplie la class Campus 
                                                      // client.CancelPendingRequests();
                return DDProf;
            }
            else
            {
                // GetBranchesError = true;
                return DDProf = Array.Empty<Prof>();
            }
        }

        public async Task LoadBati()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3000/Infrastructure/ListBatiment");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = new HttpClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDBat = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                //GetBranchesError = true;
                DDBat = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }
    }
}

