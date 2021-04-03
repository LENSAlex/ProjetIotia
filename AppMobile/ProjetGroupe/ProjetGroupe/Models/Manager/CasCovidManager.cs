using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models.Manager
{
    internal static class CasCovidManager
    {
        internal static async Task<string> SendAlert(CasCovid cas)
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = "http://51.77.137.170:8080/cascovid";
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            if (cas != null)
            {
                sb.Append(@"{""DateAlerte"" : """ + cas.DateDeContamination + @""",");
                sb.Append(@"{""PersonneId"" : """ + cas.PersonneId);
                sb.Append(@"""}");

                string jsonData = sb.ToString();
                //string json = JsonConvert.SerializeObject(item); A utiliser que si envoie d'une liste complète dès le départ.
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                //StringContent(json, Encoding.UTF8, MediaTypeHeaderValue.Parse("application/json; charset=utf-8").MediaType);
                try
                {
                    var response = await httpClient.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "ErreurInsert";
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return "ErreurTryCatch";
                }
            }
            else
            {
                return "ErreurNull";
            }
        }
    }
}