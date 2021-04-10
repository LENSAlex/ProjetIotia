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
            string WebAPIUrl = Config.WebServiceURI + "/Alerte/Covid/" + cas.PersonneId;
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            if (cas != null)
            {
                sb.Append(@"{""date_declaration"" : """ + cas.DateDeContamination + @""",");
                sb.Append(@"""id_personne"" : " + cas.PersonneId);
                sb.Append("}");

                string jsonData = sb.ToString();
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
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