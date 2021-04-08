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
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("disponible")]
        public bool Disponible { get; set; }

    } 
}
