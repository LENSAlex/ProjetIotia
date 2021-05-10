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
   
    public class CreeModifIOTDeviseModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<TypeCapteur> DDTypeCapteur { get; private set; }

        public IEnumerable<ValeurCapteur> DDValeurCapteur { get; private set; }
        public IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise> DDBox { get; private set; }

        public IEnumerable<Salle> DDSalle { get; private set; }

        public bool GetBranchesError { get; private set; }

        public CreeModifIOTDeviseModel(IHttpClientFactory clientFactory)
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

            await LoadTypeCapteur();
            await LoadIOTDevise();
            await LoadSale();
            await LoadDDValuerCapteur();
        }
        public  async Task LoadIOTDevise()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/Box/Info");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                DDBox = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.IOTDevise.IOTDevise>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDBox = Array.Empty<ClasseE_Covid.IOTDevise.IOTDevise>();
            }
        }
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
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                DDValeurCapteur = await JsonSerializer.DeserializeAsync
                <IEnumerable<ValeurCapteur>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDValeurCapteur = Array.Empty<ValeurCapteur>();
            }
        }
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
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                DDSalle = await JsonSerializer.DeserializeAsync
                <IEnumerable<Salle>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDSalle = Array.Empty<Salle>();
            }
        }
        public  async Task LoadTypeCapteur()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://webservice.lensalex.fr:3005/InfraProd/ListDevice");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                DDTypeCapteur = await JsonSerializer.DeserializeAsync
                <IEnumerable<TypeCapteur>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDTypeCapteur = Array.Empty<TypeCapteur>();
            }
        }
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

                //string json = JsonConvert.SerializeObject(item); // A utiliser que si envoie d'une liste compl�te d�s le d�part.
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

        public void OnPostEnvoieActionneur()
        {
           Actionneur actionneur = new Actionneur();

            actionneur.IdBox = Convert.ToInt32(Request.Form["idBox"]);
            actionneur.IdValueType = Convert.ToInt32(Request.Form["type"]);
            actionneur.Libelle = Request.Form["nom"];

            GetDataAsync(null , actionneur);
        }

        public void OnPostEnvoiePannauxSolaire()
        {
            PanneauSolaire panneauSolaire = new PanneauSolaire();

            panneauSolaire.IdBox = Convert.ToInt32(Request.Form["idBox"]);
            panneauSolaire.Libelle = Request.Form["nom"];

            GetDataAsync(null ,null , panneauSolaire);
        }
        public async Task GetDataAsync(ClasseE_Covid.IOTDevise.Capteur capteur = null, Actionneur actionneur = null, PanneauSolaire panneauSolaire = null)
        {
            await Save(capteur , actionneur , panneauSolaire);
        }
    }
}
