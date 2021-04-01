using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json;
namespace ClasseE_Covid
{
    public class GitHubBranch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

       //[JsonProperty("commit")]
       //public string Commit { get; set; }

        [JsonProperty("protected")]
        public string Protected { get; set; }

    } 
}
