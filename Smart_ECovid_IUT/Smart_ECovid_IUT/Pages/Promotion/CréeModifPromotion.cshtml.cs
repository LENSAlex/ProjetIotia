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
    /// <summary>
    /// CréeModifPromotionModel est la class principale du back " CréeModif.cshtml.c" de la page web " CréeModif.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le 
    /// front
    /// </summary>
    public class CréeModifPromotionModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public CréeModifPromotionModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// ModifPromo Méthode Get/Set de type PromotionClass et une méthode qui vas etre charger de la liste de promotion pour etre 
        /// ensuit utiliser dans un foreach
        /// </summary>
        public IEnumerable<PromotionClass> ModifPromo { get; private set; }

        /// <summary>
        /// DDBat Méthode Get/Set de type IEnumerable Campus   qui me permet de charger les DDBat(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<ClasseE_Covid.Campus.Campus> DDBat { get; private set; }

        /// <summary>
        /// DDProf Méthode Get/Set de type IEnumerable Prof  qui me permet de charger les DDBat(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<Prof> DDProf { get; private set; }

        /// <summary>
        /// objet de type PromotionClass qui me permetra d'afficher les valeur de la promotion que l'on veut modifier
        /// </summary>
        public PromotionClass promo;

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode   await LoadDDProf(); await LoadBati();
        /// ces méthode on un await car elle attende une reponce de API.
        /// Puis que c'est la permier méthode utiliser il y a une verification si la personne qui veut rentrait dans 
        /// cette page c'est bien login alor elle pourrat voir la page sionn elle sera rediriger vers la page de login 
        /// si id est non null je charge la methode  await LoadCampus(id); et les méthode de PutFormationId pour pouvoir 
        /// fait une requette put
        /// </summary>
        /// <param name="id">parametre qui peut etre null. ce parametre est non null quan il y a un id dans URL</param>
        /// <returns></returns>
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
                PutFormationId.IdPromo = id;
                PutFormationId.IdFormation = 1;
            }
            
            await LoadDDProf();
            await LoadBati();
        }

        /// <summary>
        /// OnPostEnvoieDonne est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode Save et lui donne un objet de type Formation en parametre
        /// </summary>
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



        /// <summary>
        /// LoadCampus est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode ModifPromo .
        /// il y a une verification si la requtte c'est bien fait. 
        /// la methode recupaire id de la promotion que l'on veut modifer pour pouvoir boucler sur la liste 
        /// de la promotion et recupéraer les bonne information de la promotion voulu . pour pouvoir les afficher dans 
        /// les Dropdwon et input 
        /// </summary>
        /// <param name="id">id dans URL</param>
        /// <returns></returns>
        public async Task LoadCampus(int? id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3001/Usager/ListPromo");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                ModifPromo = await JsonSerializer.DeserializeAsync
                <IEnumerable<PromotionClass>>(responseStream); // remplie la class Campus 
                promo = new PromotionClass();
                foreach (PromotionClass promotion in ModifPromo)
                {
                    if (promotion.Id == id)
                    {
                        promo.Nom = promotion.Nom;
                        promo.Annee = promotion.Annee;
                        promo.Duree = promotion.Duree;
                        //Département = promotion.Departemnt;
                        //idDepartement = promotion.IdDepartemnt;
                        promo.NomProf = promotion.NomProf;
                        promo.IdProf = promotion.IdProf;
                        promo.PernomProf = promotion.PernomProf;
                    }
                }
            }
            else
            {
                // GetBranchesError = true;
                ModifPromo = Array.Empty<PromotionClass>();
            }
        }

        /// <summary>
        /// Save est une méthode qui est de type async Task car elle attende une reponce de l'API
        /// elle fait une requette Post ou put  sur l'API en fonction du param PutFormationId.IdProm .
        /// il y a une verification si la requtte c'est bien fait.
        /// pour les requette post et put les valuer sont mit dans url et le jsonData ne ce doit pas d'est correcte 
        /// mais il est obligatoire. toute les post et put ce doit d'avoir un Headers.Authorization qui comporte "Bearer"et le Token
        /// qui a etait recuppérait dans le login. la différence du put c'est qu'il faut metre l'id a la fin de la requette 
        /// </summary>
        /// <param name="item">un objet de type Formation fait un post avec c'est parametre si il n'y pas null</param>
        /// <returns>Message (théoriquemet redirige sur la page web des list campus)</returns>
        internal async Task<string> Save(Formation item)
        {
            string WebAPIUrl = "";
            var httpClient = new HttpClient();

           


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
                var requestMessage = new HttpRequestMessage();

                await LoadDDProf();
                if (PutFormationId.IdPromo == null)
                {
                    WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Usager/Add/Promo/" + item.IdDepartement + "/" + item.NomFormation + "/" + item.DureeFormation + "/" + item.AnneePromotion + "/" + item.IdProfesseurPromotion;
                    requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(WebAPIUrl)
                    };

                }
                else
                {
                    WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Usager/Modif/Promo/" + item.IdDepartement + "/" + item.NomFormation + "/" + item.DureeFormation + "/" + item.AnneePromotion + "/" + item.IdProfesseurPromotion + "/" + PutFormationId.IdFormation  + "/" + PutFormationId.IdPromo;
                    requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Put,
                        Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(WebAPIUrl)
                    };
                }
              

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Login.Token);

                try
                {
                    var response = await httpClient.SendAsync(requestMessage);

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

        //public static RedirectResult Index()
        //{
        //    return new RedirectResult(url: "/Index", permanent: true,
        //                              preserveMethod: true);
        //}

        /// <summary>
        /// LoadDDProf est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDProf .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// LoadBati est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDBat .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
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

