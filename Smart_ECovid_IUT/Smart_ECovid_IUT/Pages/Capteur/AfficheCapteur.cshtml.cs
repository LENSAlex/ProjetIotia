using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClasseE_Covid.Capteur;
using ClasseE_Covid.IOTDevise;
using System.Text.Json;
using ClasseE_Covid.Campus;
using ClasseE_Covid;

namespace Smart_ECovid_IUT.Pages.Capteur
{
    /// <summary>
    /// ListeCampusModel est la class principale du back "AfficheCapteur.cshtml.c" de la page web "AfficheCapteur.cshtml"
    /// c'est dans cette class que les requette sur API sont faite et retenu dans des methode Get Set pour les utiliser dans le front 
    /// </summary>
    public class AfficheCapteurModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Temperature Méthode Get/Set de type IEnumerable Temperature qui me permet de charger tout les donner des Temperature et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Temperature> Temperature { get; private set; }

        /// <summary>
        /// Co2 Méthode Get/Set de type IEnumerable Co2 qui me permet de charger tout les donner des Co2 et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Co2> Co2 { get; private set; }

        /// <summary>
        /// Energie Méthode Get/Set de type IEnumerable Energie qui me permet de charger tout les donner des Energie et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<Energie> Energie { get; private set; }

        /// <summary>
        /// occupationSite Méthode Get/Set de type IEnumerable OccupationSite qui me permet de charger tout les donner des Occupation Site et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<OccupationSite> occupationSite { get; private set; }

        /// <summary>
        /// occupationBatiment Méthode Get/Set de type IEnumerable OccupationBatiment qui me permet de charger tout les donner des Occupation Batiment et de les afficher dans un tableau 
        /// </summary>
        public IEnumerable<OccupationBatiment> occupationBatiment { get; private set; }

        /// <summary>
        /// GetBranchesError Méthode Get/Set de type bool qui me permet de verifier si la requette et faus
        /// </summary>
        public bool GetBranchesError { get; private set; }

        /// <summary>
        /// Constructeur qui permet de charger un http client pour faire des requete (utiliser pour les Getsur API)
        /// </summary>
        /// <param name="clientFactory">Parametre charger</param>
        public AfficheCapteurModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        /// <summary>
        /// OnGet Méthode qui est utiliser des lors de l'ouverture de la page. c'est la premier méhode a etre utiliser 
        /// elle est de type  async Task pour utiliser les méhtode  await LoadCo2(); await LoadTemperatuer(); await LoadEnergie();  await LoadOccupationBatiment(); await LoadOccupationSite();
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
            await LoadCo2();
            await LoadTemperatuer();
            await LoadEnergie();
            await LoadOccupationBatiment();
            await LoadOccupationSite();
        }

        /// <summary>
        /// LoadEnergie est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Energie .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadEnergie()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/List/Historique/Energie");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Energie = await JsonSerializer.DeserializeAsync
                <IEnumerable<Energie>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Energie = Array.Empty<Energie>();
            }
        }


        /// <summary>
        /// LoadOccupationBatiment est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode occupationBatiment .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadOccupationBatiment()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3001/Usager/List/TauxOccupation/Batiment");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                occupationBatiment = await JsonSerializer.DeserializeAsync
                <IEnumerable<OccupationBatiment>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                occupationBatiment = Array.Empty<OccupationBatiment>();
            }
        }

        /// <summary>
        /// LoadOccupationSite est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode occupationSite .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadOccupationSite()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3001/Usager/List/TauxOccupation/Site");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                occupationSite = await JsonSerializer.DeserializeAsync
                <IEnumerable<OccupationSite>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                occupationSite = Array.Empty<OccupationSite>();
            }
        }

        /// <summary>
        /// LoadTemperatuer est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Temperature .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadTemperatuer()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/List/Historique/Temp");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Temperature = await JsonSerializer.DeserializeAsync
                <IEnumerable<Temperature>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Temperature = Array.Empty<Temperature>();
            }
        }

        /// <summary>
        /// LoadCo2 est une méthode qui est de type  async Task car elle attende une reponce de l'API
        /// elle fait une requette Get sur l'API est charge la méthode Co2 .
        /// il y a une verification si la requtte c'est bien fait.
        /// </summary>
        /// <returns></returns>
        public async Task LoadCo2()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/List/Historique/CO2");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
                Co2 = await JsonSerializer.DeserializeAsync
                <IEnumerable<Co2>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                Co2 = Array.Empty<Co2>();
            }
        }
    }

}
