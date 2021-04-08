using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClasseE_Covid
{
    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        //[JsonProperty("commit")]
        //public string Commit { get; set; }

        [JsonPropertyName("protected")]
        public bool Protected { get; set; }

    } 
}
