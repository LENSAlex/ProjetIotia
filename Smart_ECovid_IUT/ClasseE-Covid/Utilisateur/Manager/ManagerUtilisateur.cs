using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClasseE_Covid.Utilisateur;

namespace ClasseE_Covid.Utilisateur.Manager
{
    public class ManagerUtilisateur
    {
        //public static async Task<IEnumerable<Prof>> LoadDDProf()
        //{
        //    Prof prof = new Prof();
        //    var request = new HttpRequestMessage(HttpMethod.Get,
        //   "http://51.75.125.121:3001/Personne/ListProf");
        //    request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
        //    request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

        //    var client = new HttpClient();

        //    var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

        //    if (response.IsSuccessStatusCode)
        //    {
        //       using var responseStream2 = await response.Content.ReadAsStreamAsync(); // recupaire les donnée de api et les mette dans le responseStream
        //        prof.DDProf = await JsonSerializer.DeserializeAsync
        //        <IEnumerable<Prof>>(responseStream2); // remplie la class Campus 
        //                                              // client.CancelPendingRequests();
        //        return prof.DDProf;
        //    }
        //    else
        //    {
        //        // GetBranchesError = true;
        //      return prof.DDProf =  Array.Empty<Prof>();
        //    }
        //}
    }
}
