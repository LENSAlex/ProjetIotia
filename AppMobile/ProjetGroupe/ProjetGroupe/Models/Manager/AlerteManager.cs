﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models.Manager
{
    internal static class AlerteManager
    {
        internal static async Task<bool> SendAlert()
        {
            var httpClient = new HttpClient();
            string WebAPIUrl = Configuration.BackendServiceEndpoint + "api/notifications/requests";
            Uri uri = new Uri(WebAPIUrl);
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            StringBuilder sb = new StringBuilder();

            sb.Append(@"{""text"" : ""Attention, une personne a été signalé ayant la covid"",");
            sb.Append(@"""action"" : ""action_a""");
            sb.Append("}");

            string jsonData = sb.ToString();
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync(uri, content);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
