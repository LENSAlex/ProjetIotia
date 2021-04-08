using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClasseE_Covid;
using System.Net;
using System.Text.Json;
//using Newtonsoft.Json;


namespace Smart_ECovid_IUT.Pages
{
    public class PrivacyModel : PageModel
    {
      //  public string element { get; set;}
        private readonly ILogger<PrivacyModel> _logger;

        private readonly IHttpClientFactory _clientFactory;

         public IEnumerable<GitHubBranch> Branches { get; private set; } //GitHubBranch et une class

        public bool GetBranchesError { get; private set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task OnGet() // tache asycrene attent une reponce tache awit  https://api.github.com/repos/dotnet/AspNetCore.Docs/branches
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://51.75.125.121:8080/testlolo2"); 
            request.Headers.Add("Accept", "application/json");  //application/vnd.github.v3+json"
            request.Headers.Add("User-Agent", ".NET Foundation Repository Reporter");   //"HttpClientFactory-Sample"

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request); // vus que la fonction est async elle vas s'arreter ici pour attendre une reponce 

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }
        }
    }
}

