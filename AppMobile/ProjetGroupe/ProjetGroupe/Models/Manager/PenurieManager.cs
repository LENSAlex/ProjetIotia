using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models.Manager
{
    internal static class PenurieManager
    {
        internal static async Task<string> UpdateStock(Penurie item)
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = "http://51.77.137.170:8080/Alerte/Covid/Personne";
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            if (item != null)
            {
                sb.Append(@"{""IsPenurie"" : " + item.Is_Penurie + ",");
                sb.Append(@"""DatePenurie"" : """ + item.date_maj + @""",");
                sb.Append(@"""EquipementId"" : " + item.Id_Equipement + ",");
                sb.Append(@"""SalleId"" : " + item.SalleId);
                sb.Append("}");

                string jsonData = sb.ToString();
                //string json = JsonConvert.SerializeObject(item); A utiliser que si envoie d'une liste complète dès le départ.
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    var response = await httpClient.PutAsync(uri, content);
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
                    Debug.WriteLine(e.Message);
                    return "ErreurTryCatch";
                }
            }
            else
            {
                Debug.WriteLine("ErreurPenurieNull");
                return "ErreurPenurieNull";
            }
        }
    }
}
