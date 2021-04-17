using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models.Manager
{
    /// <summary>
    /// Classe Manager Pénurie
    /// </summary>
    internal static class PenurieManager
    {
        /// <summary>
        /// Fonction faisant une requête PUT vers l'API REST en prenant en param un objet Pénurie contenant l'id de l'équipement et l'id de la salle ou se trouve la pénurie
        /// </summary>
        /// <param name="item">Objet Penurie</param>
        /// <returns>"Ok" si code = 200 sinon erreur</returns>
        internal static async Task<string> UpdateStock(Penurie item)
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = Config.WebServiceURI + "/Alerte/IsPenurie/" + item.Id_Equipement + "/" + item.SalleId;
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            if (item != null)
            {
                sb.Append(@"{""id_equipement"" : " + item.Id_Equipement + ",");
                sb.Append(@"""id_salle"" : " + item.SalleId);
                sb.Append("}");

                string jsonData = sb.ToString();
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
