using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.IOTDevise;
using ClasseE_Covid.Capteur;
using ClasseE_Covid.Campus;
using System.Text.Json;
using ClasseE_Covid;
using System.Net.Http.Headers;

namespace Smart_ECovid_IUT.Pages.IOTDevise
{
    /// <summary>
    /// CreeModifIOTDeviseModel est la class principale du back "CreeModifIOTDevise.cshtml.c" de la page web "CreeModifIOTDevise.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le 
    /// front
    /// </summary>
    public class CreeModifIOTDeviseModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        /// <summary>
        /// DDTypeCapteur Méthode Get/Set de type IEnumerable TypeCapteur   qui me permet de charger les DDTypeCapteur(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<TypeCapteur> DDTypeCapteur { get; private set; }

        /// <summary>
        /// DDValeurCapteur Méthode Get/Set de type IEnumerable ValeurCapteur   qui me permet de charger les DDValeurCapteur(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<ValeurCapteur> DDValeurCapteur { get; private set; }

        /// <summary>
        /// DDBox Méthode Get/Set de type IEnumerable IOTDevise   qui me permet de charger les DDBox(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise> DDBox { get; private set; }

        /// <summary>
        /// DDSalle Méthode Get/Set de type IEnumerable Salle  qui me permet de charger les DDSalle(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<Salle> DDSalle { get; private set; }

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public CreeModifIOTDeviseModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode  await LoadTypeCapteur(); await LoadIOTDevise();await LoadSale();await LoadDDValuerCapteur();
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

            await LoadTypeCapteur();
            await LoadIOTDevise();
            await LoadSale();
            await LoadDDValuerCapteur();
        }

        /// <summary>
        /// LoadIOTDevise est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDBox .
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
                DDBox = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDBox = Array.Empty<ClasseE_Covid.IOTDevise.IOTDevise>();
            }
        }

        /// <summary>
        /// LoadDDValuerCapteur est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDValeurCapteur .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDDValuerCapteur()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/ListValueType");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDValeurCapteur = await JsonSerializer.DeserializeAsync
                <IEnumerable<ValeurCapteur>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDValeurCapteur = Array.Empty<ValeurCapteur>();
            }
        }

        /// <summary>
        /// LoadSale est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDSalle .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadSale()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3000/Infrastructure/ListSalle");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDSalle = await JsonSerializer.DeserializeAsync
                <IEnumerable<Salle>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDSalle = Array.Empty<Salle>();
            }
        }

        /// <summary>
        /// LoadTypeCapteur est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDTypeCapteur.
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadTypeCapteur()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/ListDevice");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDTypeCapteur = await JsonSerializer.DeserializeAsync
                <IEnumerable<TypeCapteur>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDTypeCapteur = Array.Empty<TypeCapteur>();
            }
        }

        /// <summary>
        /// Save est une méthode qui est de type async Task car elle attende une reponce de l'API
        /// elle fait une requette Post sur l'API en fonction du param qui n'est pas null.
        /// il y a une verification si la requtte c'est bien fait. 
        /// pour les requette post les valuer post sont mit dans url le jsonData ne ce doit pas d'étre correcte 
        /// mais il est obligatoire. toute les post ce doit d'avoir un Headers.Authorization qui comporte "Bearer"et le Token
        /// qui a etait recuppérait dans le login
        /// </summary>
        /// <param name="capteur">un objet de type Capteur fait un post avec c'est parametre si il n'y pas null</param>
        /// <param name="actionneur">un objet de type Actionneur fait un post avec c'est parametre si il n'y pas null</param>
        /// <param name="panneauSolaire">un objet de type PanneauSolaire fait un post avec c'est parametre si il n'y pas null</param>
        /// <returns> Message (théoriquemet redirige sur la page web des list campus)</returns>
        internal async Task<string> Save(ClasseE_Covid.IOTDevise.Capteur capteur , Actionneur actionneur , PanneauSolaire panneauSolaire)
        {
            var httpClient = new HttpClient();
            StringBuilder sb = new StringBuilder();
            string WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/";
           // Uri uri = new Uri(uriBase);

            if (capteur != null)
            {
                // /app.post("/Capteur/Add/BoxDevice/:IdSalle/:IdDeviceType/:AddrMac/:AddrIp/:LibelleBox/:DescriptionBox/:DateInstallation/:IdValueType/:LibelleDevice/:SeuilMin?/:SeuilMax?", (req, res) => {
                 WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Capteur/Add/BoxDevice/" + capteur.IdSalle + "/" + capteur.IdDeviceType + "/" + capteur.AddrMac + "/" + capteur.AddrIp + "/" + capteur.LibelleBox + "/" + capteur.DescriptionBox + "/" + capteur.DateInstallation + "/" + capteur.IdValeurType + "/" + capteur.LibelleDevice + "/" + capteur.SeuilMin + "/" + capteur.SeuilMax;

                //string WebAPIUrl = "http://51.75.125.121:3001/Capteur/Add/BoxDevice/" + capteur.IdSalle + "/" + capteur.IdDeviceType + "/" + capteur.AddrMac + "/" + capteur.AddrIp + "/" + capteur.LibelleBox + "/" + capteur.DescriptionBox + "/"+ capteur.DateInstallation + "/" + capteur.IdValueType + "/" + capteur.LibelleDevice + "/" + capteur.SeuilMin + "/" + capteur.SeuilMax;
                //uri = new Uri(WebAPIUrl);
                sb.Append(@"{""IdSalle"" : " + capteur.IdSalle + ",");
                sb.Append(@"""IdDeviceType"" : " + capteur.IdDeviceType + ",");
                sb.Append(@"""AddrMac"" : """ + capteur.AddrMac + @""",");
                sb.Append(@"""AddrIp"" :  """ + capteur.AddrIp + @""", ");
                sb.Append(@"""LibelleBox"" : """ + capteur.LibelleBox + @""",");
                sb.Append(@"""DescriptionBox"" : """ + capteur.DescriptionBox + @""",");
                sb.Append(@"""DateInstallation"" : """ + capteur.DateInstallation + @""",");
                sb.Append(@"""IdValueType"" : " + capteur.IdValeurType + ",");
                sb.Append(@"""LibelleDevice"" : """ + capteur.LibelleDevice + @""",");
                sb.Append(@"""SeuilMin"" : " + capteur.SeuilMin + ",");
                sb.Append(@"""SeuilMax"" : " + capteur.SeuilMax);
                sb.Append("}");

            }
            else if (actionneur != null)
            {
                WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Capteur/Add/Actionneur/" + actionneur.IdBox + "/" + actionneur.IdValueType + "/" + actionneur.Libelle;
                //uri = new Uri(WebAPIUrl);
                sb.Append(@"{""IdBox"" : " + actionneur.IdBox + ",");
                sb.Append(@"""IdValueType"" : " + actionneur.IdValueType + ",");
                sb.Append(@"""Libelle"" : """ + actionneur.Libelle + @""",");
                sb.Append("}");
            }
            else if (panneauSolaire != null)
            {
                 WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Capteur/Add/PanneauSolaire/" + panneauSolaire.IdBox + "/" + panneauSolaire.Libelle;
                //uri = new Uri(WebAPIUrl);
                sb.Append(@"{""IdSalle"" : " + panneauSolaire.IdBox + ",");
                sb.Append(@"""IdDeviceType"" : """ + panneauSolaire.Libelle + @""",");
                sb.Append("}");

            }            
           // httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
           
            if (capteur!= null || actionneur != null || panneauSolaire != null)
            {
                await LoadTypeCapteur();
                await LoadIOTDevise();
                string jsonData = sb.ToString();

                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                    RequestUri = new Uri(WebAPIUrl)
                };

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Login.Token);

                //string json = JsonConvert.SerializeObject(item); // A utiliser que si envoie d'une liste complète dès le départ.
                // StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    var response = await httpClient.SendAsync(requestMessage);
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

        /// <summary>
        /// OnPostEnvoieCapteur est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode GetDataAsync et lui donne un objet de type Capteur en parametre
        /// sont dexieme et troisieme parametre n'a pas besoin etre ecrit car il est null de base
        /// </summary>
        public void OnPostEnvoieCapteur()
        {
            ClasseE_Covid.IOTDevise.Capteur capteur = new ClasseE_Covid.IOTDevise.Capteur();

            capteur.LibelleDevice = Request.Form["nom"];
            capteur.IdValeurType = Convert.ToInt32(Request.Form["valeurCapteur"]);
            capteur.IdDeviceType = Convert.ToInt32(Request.Form["idTypeDevice"]);
            capteur.DescriptionBox = Request.Form["descriptionBox"];
            capteur.LibelleBox = Request.Form["nomBox"];
            capteur.IdSalle = Convert.ToInt32(Request.Form["idSale"]);
            capteur.AddrMac = Request.Form["mac"];
            capteur.AddrIp = Request.Form["ip"];
            capteur.DateInstallation = Request.Form["installation"];
            capteur.SeuilMin = Convert.ToInt32(Request.Form["seuilMin"]);
            capteur.SeuilMax = Convert.ToInt32(Request.Form["seuilMax"]);

            GetDataAsync(capteur);
        }

        /// <summary>
        /// OnPostEnvoieActionneur est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode GetDataAsync et lui donne un objet de type Actionneur en parametre
        ///  troisieme parametre n'a pas besoin etre ecrit car il est null de base
        /// </summary>
        public void OnPostEnvoieActionneur()
        {
           Actionneur actionneur = new Actionneur();

            actionneur.IdBox = Convert.ToInt32(Request.Form["idBox"]);
            actionneur.IdValueType = Convert.ToInt32(Request.Form["type"]);
            actionneur.Libelle = Request.Form["nom"];

            GetDataAsync(null , actionneur);
        }

        /// <summary>
        /// OnPostEnvoiePannauxSolaire est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode GetDataAsync et lui donne un objet de type PanneauSolaire en parametre
        /// </summary>
        public void OnPostEnvoiePannauxSolaire()
        {
            PanneauSolaire panneauSolaire = new PanneauSolaire();

            panneauSolaire.IdBox = Convert.ToInt32(Request.Form["idBox"]);
            panneauSolaire.Libelle = Request.Form["nom"];

            GetDataAsync(null ,null , panneauSolaire);
        }

        /// <summary>
        /// cette méthode sert de passerelle entre les methode du from et celui du save pour mettre les bon parametre 
        /// </summary>
        /// <param name="capteur">Objet de type Capteur qui est null de base  </param>
        /// <param name="actionneur">Objet de type Actionneur qui est null de base  </param>
        /// <param name="panneauSolaire">Objet de type PanneauSolaire qui est null de base  </param>
        /// <returns></returns>
        public async Task GetDataAsync(ClasseE_Covid.IOTDevise.Capteur capteur = null, Actionneur actionneur = null, PanneauSolaire panneauSolaire = null)
        {
            await Save(capteur , actionneur , panneauSolaire);
        }
    }
}
