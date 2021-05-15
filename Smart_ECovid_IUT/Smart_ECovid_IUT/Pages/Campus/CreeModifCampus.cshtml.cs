using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Campus;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ClasseE_Covid;
using System.Net.Http.Headers;
//using Newtonsoft.Json;

namespace Smart_ECovid_IUT.Pages.Campus
{
    /// <summary>
    /// CreeModifCampusModel est la class principale du back "CreeModifCampus.cshtml.c" de la page web "CreeModifCampus.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le 
    /// front
    /// </summary>
    public class CreeModifCampusModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>  DDBatiment Méthode Get/Set de type IEnumerable Campus  qui me permet de charger les batiment(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<ClasseE_Covid.Campus.Campus> DDBatiment { get; private set; }

        /// <summary>
        /// DDCampus Méthode Get/Set de type IEnumerable Campus   qui me permet de charger les DDCampus(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<ClasseE_Covid.Campus.Campus> DDCampus { get; private set; } //IOTDevise et une class

        /// <summary>
        /// etage  Méthode Get/Set de type  IEnumerable Etage qui me permet de charger les DDCampus(nom ,id) et de les afficher dans une DropDown 
        /// pour faire mon formulaire. Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public IEnumerable<Etage> etage { get; set; } //IOTDevise et une class

        /// <summary>
        /// DDEtage Méthode Get/Set de type DDEtage qui me permet de charger les Etage(nom ,id) et de les afficher dans une DropDown dans le partial _PartialCreeIOTDevise
        /// pour faire mon formulaire.Il est afficher grace a un foreach qui boucle dessu sur le front
        /// </summary>
        public List<DDEtage> DDEtage = new List<DDEtage>();

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public CreeModifCampusModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode await LoadDDBatiment(); await LoadDDCampus();. 
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
            await LoadDDBatiment();
            await LoadDDCampus();
            //await LoadDDEtage();
        }

        /// <summary>
        /// LoadDDEtage est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode etage .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDDEtage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3000/Infrastructure/ListEtage"); // fait la requtte Get sur URL
            request.Headers.Add("Accept", "application/json"); 
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");  

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                etage = await JsonSerializer.DeserializeAsync
                <IEnumerable<Etage>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                etage = Array.Empty<Etage>();
            }
        }

        /// <summary>
        /// LoadDDCampus est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDCampus .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDDCampus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3000/Infrastructure/ListSite");// fait la requtte Get sur URL
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");  

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDCampus = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDCampus = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }

        /// <summary>
        /// LoadDDBatiment est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode DDBatiment .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDDBatiment()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
          "http://webservice.lensalex.fr:3000/Infrastructure/ListBatiment"); // fait la requtte Get sur URL
            request.Headers.Add("Accept", "application/json");  
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                DDBatiment = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDBatiment = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }

        /// <summary>
        /// SaveBatiment est une méthode qui est de type async Task car elle attende une reponce de l'API
        /// elle fait une requette Post sur l'API en fonction du param qui n'est pas null.
        /// il y a une verification si la requtte c'est bien fait.
        /// le post de l'objet item attent une json pour crée la superfici des etage. il et ensuite mit dans url 
        /// pour les requette post les valuer post sont mit dans url le jsonData ne ce doit pas d'est correcte 
        /// mais il est obligatoire. toute les post ce doit d'avoir un Headers.Authorization qui comporte "Bearer"et le Token
        /// qui a etait recuppérait dans le login
        /// </summary>
        /// <param name="item">un objet de type PostBatiementEtage fait un post avec c'est parametre si il n'y pas null</param>
        /// <param name="salle">un objet de type PostBatimentSalle fait un post avec c'est parametre si il n'y pas null</param>
        /// <returns>Message (théoriquemet redirige sur la page web des list campus)</returns>
        internal async Task<string> SaveBatiment(PostBatiementEtage item = null, PostBatimentSalle salle = null)
        {
            var httpClient = new HttpClient();
            StringBuilder lesEtage = new StringBuilder();

            // StringContent EtageSuperficie = new StringContent(jsonEtage, Encoding.UTF8, "application/json");

            StringBuilder sb = new StringBuilder();

            string WebAPIUrl = "";
            if (salle != null)
            {
                WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Infrastructure/Add/Salle/" + salle.IdEtage + "/" + salle.NomSalle + "/" + salle.CapaciteMax + "/" + salle.SalleSurface + "/" + salle.Volume;
                sb.Append(@"{""Nom"" : " + salle.IdEtage + ",");
                sb.Append(@"""Superficie"" : """ + salle.NomSalle + @""",");
                sb.Append(@"""IdCampus"" : " + salle.CapaciteMax + ",");
                sb.Append(@"""Superficie"" : " + salle.SalleSurface + ",");
                sb.Append(@"""IdCampus"" : " + salle.Volume + "}");
            }
            else
            {
                lesEtage.Append(@"{""SuperficieEtage"" : [");
                for (int i = 0; i < item.NbEtage; i++)
                {
                    int cnt = 1 + i;
                    string virgule = "";
                    if (i < (item.NbEtage - 1))
                    {
                        virgule = ",";
                    }
                    lesEtage.Append(@"{""Etage"" : """ + Convert.ToString(i) + @""",");
                    lesEtage.Append(@"""Superficie"" : """ + item.EtageSuperficie[i] + @"""}" + virgule + "");
                }
                lesEtage.Append(@"]}");

                string jsonEtage = lesEtage.ToString();
                var lejson = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonEtage);

                WebAPIUrl = "http://webservice.lensalex.fr:3004/InfraAdmin/Infrastructure/Add/Batiment/" + item.Nom + "/" + item.Superficie + "/" + item.IdCampus + "/" + lejson;
                sb.Append(@"{""Nom"" : """ + item.Nom + @""",");
                sb.Append(@"""Superficie"" : " + item.Superficie + ",");
                sb.Append(@"""IdCampus"" : " + item.IdCampus + ",");
                sb.Append(@"""SuperifieEtage"" : [");
                for (int i = 0; i < item.NbEtage; i++)
                {
                    string virgule = "";
                    if (i < (item.NbEtage - 1))
                    {
                        virgule = ",";
                    }
                    sb.Append(@"{""Etage"" : """ + Convert.ToString(i) + @""",");
                    sb.Append(@"""Superficie"" : """ + item.EtageSuperficie[i] + @"""}" + virgule + "");
                }
                sb.Append(@"]");
                sb.Append("}");
            }

            //string WebAPIUrl = "http://51.75.125.121:3000/Batiment/Add/Batiment/" + item.Nom + "/" + item.Superficie + "/" + item.IdCampus + "/" + lejson;
            //Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
         
            if (item != null || salle != null)
            {

                string jsonData = sb.ToString();
                await LoadDDBatiment();
                await LoadDDCampus();

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
                    //var response = await httpClient.PostAsync(uri, formData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        await LoadDDBatiment();
                        await LoadDDCampus();
                        Response.Redirect("/Campus/ListeCampus");
                        return "Ok";
                    }
                    else
                    {
                        return "ErreurStatusCode";
                    }
                }
                catch (Exception e)
                {
                    return "ErreurTryCatch";
                }
            }
            else
            {
                return "ErreurCapteurNull";
            }
        }

        /// <summary>
        /// OnPostEnvoieDonne est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode GetDataAsync et lui donne un objet de type PostBatiementEtage en parametre
        /// sont dexieme parametre n'a pas besoin etre ecrit car il est null de base
        /// </summary>
        public void OnPostEnvoieDonne()
        {
            PostBatiementEtage campus = new PostBatiementEtage();

            campus.Nom = Request.Form["nom"];
            campus.Superficie = Convert.ToInt32(Request.Form["surface"]);
            campus.NbEtage = Convert.ToInt32(Request.Form["etage"]);
            campus.IdCampus = Convert.ToInt32(Request.Form["campus"]);

            campus.EtageSuperficie = new string[campus.NbEtage];

            for (int i = 0; i < campus.NbEtage; i++)
            {
                campus.EtageSuperficie[i] = Request.Form["superfice" + i + ""];
            }

            GetDataAsync(campus);
        }


        /// <summary>
        /// OnPostEnvoieDonneSalle est une méthode qui appler lors de l'envoie du formulaire grace  "asp-page-handler" 
        /// le OnPost devent le nom est obligatoire en .Net core il indicque que le form et en Post
        /// il vas donc recupérait les reponce ranplie dans le formulaire et les charger dans un objer 
        /// elle apple la méthode GetDataAsync et lui donne un objet de type PostBatimentSalle en parametre 
        /// </summary>
        public void OnPostEnvoieDonneSalle()
        {
            PostBatimentSalle salle = new PostBatimentSalle();

            salle.IdEtage = Convert.ToInt32(Request.Form["etage"]);
            salle.NomSalle = Request.Form["nomSalle"];
            salle.CapaciteMax = Convert.ToInt32(Request.Form["capacite"]);
            salle.SalleSurface = Convert.ToInt32(Request.Form["surface"]);
            salle.Volume = Convert.ToInt32(Request.Form["volume"]);


            GetDataAsync(null, salle);
        }

        /// <summary>
        /// cette méthode sert de passerelle entre les methode du from et celui du save pour mettre les bon parametre 
        /// </summary>
        /// <param name="campus"></param>
        /// <param name="salle"></param>
        /// <returns></returns>
        public async Task GetDataAsync(PostBatiementEtage campus = null, PostBatimentSalle salle = null)
        {
            if (campus != null)
                await SaveBatiment(campus);
            else
                await SaveBatiment(null, salle);
            await LoadDDBatiment();
            await LoadDDCampus();
        }

        /// <summary>
        /// OnGetEtageCharge et une methode qui est utiliser pour charger une DropDown en fonction du batiment choise 
        /// cette méthode et activer par de l'ajax dans le front qui recuper le nom du batiment et vas charger tout les 
        /// etage du batiment dans la methode. la list d'etage sera utiliser ensut dan le partial _PartialCreeIOTDevise
        /// </summary>
        /// <param name="nomBatiment">Nom du batiment choisi dans le form</param>
        /// <returns>elle retune le resulta dans le partial PartialIOTDevise/_PartialCreeIOTDevise</returns>
        public async Task<PartialViewResult> OnGetEtageCharge(string nomBatiment)
        {
            await LoadDDEtage();
            foreach (Etage Letage in etage)
            {
                await LoadDDEtage();
                if (nomBatiment == Letage.NomBatiment)
                {
                    DDEtage.Add(new DDEtage { DDIdEtage = Letage.IdEtage, DDNumEtage = Letage.NumEtage });
                }
            }
            await LoadDDBatiment();
            await LoadDDCampus();

            return Partial("PartialIOTDevise/_PartialCreeIOTDevise", this);
        }
    }
}
