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
//using Newtonsoft.Json;

namespace Smart_ECovid_IUT.Pages.Campus
{
    public class CreeModifCampusModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<ClasseE_Covid.Campus.Campus> DDBatiment { get; private set; } //IOTDevise et une class
        public IEnumerable<ClasseE_Covid.Campus.Campus> DDCampus { get; private set; } //IOTDevise et une class

        public IEnumerable<Etage> etage { get; set; } //IOTDevise et une class

        // public List<Tuple<int, String>> DDEtage = new List<Tuple<int, String>>(); 
        public List<DDEtage> DDEtage = new List<DDEtage>();

        public bool GetBranchesError { get; private set; }

        public CreeModifCampusModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            await LoadDDBatiment();
            await LoadDDCampus();
            //await LoadDDEtage();
        }

        public async Task LoadDDEtage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Batiment/ListEtage");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                etage = await JsonSerializer.DeserializeAsync
                <IEnumerable<Etage>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                etage = Array.Empty<Etage>();
            }
        }

        public async Task LoadDDCampus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "http://51.75.125.121:3001/Batiment/ListSite");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                DDCampus = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDCampus = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }

        public async Task LoadDDBatiment()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
          "http://51.75.125.121:3001/Batiment/ListBatiment");
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donn�e de api et les mette dans le responseStream
                DDBatiment = await JsonSerializer.DeserializeAsync
                <IEnumerable<ClasseE_Covid.Campus.Campus>>(responseStream2); // remplie la class Campus 
            }
            else
            {
                GetBranchesError = true;
                DDBatiment = Array.Empty<ClasseE_Covid.Campus.Campus>();
            }
        }


        internal  async Task<string> SaveBatiment(PostBatiementEtage item)
        {
           // await LoadDDBatiment();
          //  await LoadDDCampus();
            var httpClient = new HttpClient();
            StringBuilder lesEtage = new StringBuilder();

            lesEtage.Append(@"{""SuperficieEtage"" : [");
            for (int i = 0; i < item.NbEtage; i++)
            {
                int cnt = 1 + i;
                string virgule = "";
                if(i < (item.NbEtage - 1))
                {
                    virgule = ",";
                }
                lesEtage.Append(@"{""Etage"" : """ + Convert.ToString(i) + @""",");
                lesEtage.Append(@"""Superficie"" : """ + item.EtageSuperficie[i] + @"""}"+virgule+"");
            }
            lesEtage.Append(@"]}");

            string jsonEtage = lesEtage.ToString();
            var lejson = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonEtage);

            StringContent EtageSuperficie = new StringContent(jsonEtage, Encoding.UTF8, "application/json");
            
            // /Batiment / Add / Batiment / :Nom / :Superficie / :IdCampus / :EtageSuperficie
            string WebAPIUrl = "http://51.75.125.121:3001/Batiment/Add/Batiment/" + item.Nom + "/" + item.Superficie + "/" + item.IdCampus + "/" + lejson;
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();
            if (item != null)
            {
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

              //  await LoadDDBatiment();
              //  await LoadDDCampus();

                string jsonData = sb.ToString();
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    var response = await httpClient.PostAsync(uri, content);
                    //var response = await httpClient.PostAsync(uri, formData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        await LoadDDBatiment();
                        await LoadDDCampus();
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

        public async Task GetDataAsync(PostBatiementEtage campus)
        {
            await SaveBatiment(campus);
            await LoadDDBatiment();
            await LoadDDCampus();
        }

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
