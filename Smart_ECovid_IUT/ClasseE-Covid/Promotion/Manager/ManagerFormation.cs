using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid.Utilisateur.Manager;

namespace ClasseE_Covid.Promotion.Manager
{
    class ManagerFormation
    {
        ManagerUtilisateur managerUtilisateur;
        internal static async Task<string> Save(Formation item)
        {
            ///Personne/Add/Promo/:IdDepartement/:NomFormation/:DureeFormation/:AnneePromotion/:IdProfesseurPromotion
            string WebAPIUrl = "http://51.75.125.121:3001/Personne/Add/Promo/" + item.IdDepartement + "/" + item.NomFormation + "/" + item.DureeFormation + "/" + item.AnneePromotion + "/" + item.IdProfesseurPromotion;
            Uri uri = new Uri(WebAPIUrl);

            //var request = new HttpRequestMessage(HttpMethod.Post,WebAPIUrl);
            //request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            //request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            //var client = _clientFactory.CreateClient();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
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
                //string json = JsonConvert.SerializeObject(item); A utiliser que si envoie d'une liste complète dès le départ.
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    await ManagerUtilisateur.LoadDDProf();
                    var response = await httpClient.PostAsync(uri, content);
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

        
    }
}
