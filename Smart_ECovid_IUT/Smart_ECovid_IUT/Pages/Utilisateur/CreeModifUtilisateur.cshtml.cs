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
using ClasseE_Covid;
using System.Net.Http.Headers;

namespace Smart_ECovid_IUT.Pages.Utilisateur
{
    /// <summary>
    /// CreeModifUtilisateurModel est la class principale du back " CreeModifUtilisateur.cshtml.c" de la page web " CreeModifUtilisateur.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le 
    /// front
    /// </summary>
    public class CreeModifUtilisateurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        /// <summary>
        /// objet de type Utilisateur qui me permetra d'afficher les valeur de la Utilisateur que l'on veut modifier
        /// </summary>
        public ClasseE_Covid.Utilisateur.Utilisateur utilisateur;

        /// <summary>
        /// DDNiveau Méthode Get/Set de type IEnumerable Niveau  qui me permet de charger les Niveau(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<Niveau> DDNiveau { get; private set; }



        /// <summary>
        /// User Méthode Get/Set de type Utilisateur et une méthode qui vas etre charger de la liste de promotion pour etre 
        /// ensuit utiliser dans un foreach
        /// </summary>
        public IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur> User { get; private set; }

        /// <summary>
        /// DDPromotion Méthode Get/Set de type IEnumerable PromotionClass  qui me permet de charger les Promotion(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<PromotionClass> DDPromotion { get; private set; }


        //   public IEnumerable<PromotionClass> ModifUser { get; private set; }

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public CreeModifUtilisateurModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode   await LoadDDNiveau();  await LoadFormation();
        /// ces méthode on un await car elle attende une reponce de API.
        /// Puis que c'est la permier méthode utiliser il y a une verification si la personne qui veut rentrait dans 
        /// cette page c'est bien login alor elle pourrat voir la page sionn elle sera rediriger vers la page de login 
        /// si id est non null je charge la methode  await LoadUtilisateur(id); et l'objet  utilisateur pour pouvoir 
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
                GetUtilisateurById.Id = id;
                await LoadUtilisateur(id);
            }
            await LoadDDNiveau();
            await LoadFormation();

        }

        /// <summary>
        /// LoadUtilisateur est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode utilisateur .
        /// il y a une verification si la requtte c'est bien fait. 
        /// la methode recupaire id de la utilisateur que l'on veut modifer pour pouvoir boucler sur la liste 
        /// de la utilisateur et recupéraer les bonne information de la utilisateur voulu . pour pouvoir les afficher dans 
        /// les Dropdwon et input 
        /// </summary>
        /// <param name="id">id dans URL</param>
        /// <returns></returns>
        public async Task LoadUtilisateur(int? id)
        {
           
            var request = new HttpRequestMessage(HttpMethod.Get,
          "http://webservice.lensalex.fr:3001/Usager/Load/User/" + id);
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                User = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Utilisateur.Utilisateur>>(responseStream2); // remplie la class Campus 

                utilisateur = new ClasseE_Covid.Utilisateur.Utilisateur();
                foreach (ClasseE_Covid.Utilisateur.Utilisateur user in User)
                {
                    utilisateur.Anniv = user.Anniv;
                    utilisateur.Email = user.Email;
                    utilisateur.IdPersType = user.IdPersType;
                    utilisateur.Niveau = user.Niveau;
                    utilisateur.Nom = user.Nom;
                    utilisateur.NomFormation = user.NomFormation;
                    utilisateur.NumRef = user.NumRef;
                    utilisateur.Prenom = user.Prenom;
                    utilisateur.Sexe = user.Sexe;
                    utilisateur.Telephone = user.Telephone;
                    utilisateur.Promotion = user.Promotion;
                    utilisateur.Pwd = user.Pwd;
                    utilisateur.Pwd = user.Pwd;
                }
            }
            else
            {
                GetBranchesError = true;
                User = Array.Empty<ClasseE_Covid.Utilisateur.Utilisateur>();
            }
        }

        /// <summary>
        /// LoadDDNiveau est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDNiveau .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDDNiveau()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
          "http://webservice.lensalex.fr:3001/Usager/ListTypePersonne");
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

        /// <summary>
        /// LoadFormation est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDPromotion .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadFormation()
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
                DDPromotion = await JsonSerializer.DeserializeAsync
                <IEnumerable<PromotionClass>>(responseStream); // remplie la class GitHubBranch 
            }
            else
            {
                GetBranchesError = true;
                DDPromotion = Array.Empty<PromotionClass>();
            }
        }

        /// <summary>
        /// Save est une méthode qui est de type async Task car elle attende une reponce de l'API
        /// elle fait une requette Post ou put  sur l'API en fonction du param GetUtilisateurById.Id .
        /// il y a une verification si la requtte c'est bien fait.
        /// pour les requette post et put les valuer post sont mit dans url et le jsonData ne ce doit pas d'est correcte 
        /// mais il est obligatoire. toute les post et put ce doit d'avoir un Headers.Authorization qui comporte "Bearer"et le Token
        /// qui a etait recuppérait dans le login. la différence du put c'est qu'il faut metre l'id a la fin de la requette 
        /// </summary>
        /// <param name="item">un objet de type Utilisateur fait un post avec c'est parametre si il n'y pas null</param>
        /// <returns>Message (théoriquemet redirige sur la page web des list campus)</returns>
        internal async Task<string> Save(ClasseE_Covid.Utilisateur.Utilisateur item)
        {
            var httpClient = new HttpClient();

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

                var requestMessage = new HttpRequestMessage();

                if (GetUtilisateurById.Id != null)
                {
                    string WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Usager/Modifs/" + item.NumRef + "/" + item.IdPersType + "/" + item.Pwd + "/" + item.Email + "/" + item.Telephone + "/" + item.Sexe + "/" + item.Nom + "/" + item.Prenom + "/" + item.Anniv + "/" + item.Promotion + "/" + GetUtilisateurById.Id;

                    requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Put,
                        Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(WebAPIUrl)
                    };

                    utilisateur = null;
                }
                else
                {
                    string WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Usager/Add/" + item.NumRef + "/" + item.IdPersType + "/" + item.Pwd + "/" + item.Email + "/" + item.Telephone + "/" + item.Sexe + "/" + item.Nom + "/" + item.Prenom + "/" + item.Anniv + "/" + item.Promotion;

                    requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
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
                        Response.Redirect("/Index");
                        return "ok";
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

        /// <summary>
        /// OnPostEnvoieDonne est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode Save et lui donne un objet de type Utilisateur en parametre
        /// </summary>
        public void OnPostEnvoieDonne()
        {
            ClasseE_Covid.Utilisateur.Utilisateur user = new ClasseE_Covid.Utilisateur.Utilisateur(); ;

            user.Prenom = Request.Form["prenom"];
            user.Nom = Request.Form["nom"];
            user.NumRef = Request.Form["num_ref"];
            user.IdPersType = Convert.ToInt32(Request.Form["niveau"]);
            user.Pwd = Request.Form["pwd"];
            string pwd = Request.Form["pwd2"];
            user.Email = Request.Form["email"];
            user.Telephone = Request.Form["tel"];
            user.Sexe = Request.Form["sexe"];
            user.Anniv = Request.Form["anniv"];
            user.Promotion = Convert.ToInt32(Request.Form["formation"]);

            GetDataAsync(user);
        }

        /// <summary>
        /// cette méthode sert de passerelle entre les methode du from et celui du save pour mettre les bon parametre 
        /// </summary>
        /// <returns></returns>
        public async Task GetDataAsync(ClasseE_Covid.Utilisateur.Utilisateur user)
        {
            await Save(user);
             Response.Redirect("/Utilisateur/ListeUtilisateur");
        }
    }
}
