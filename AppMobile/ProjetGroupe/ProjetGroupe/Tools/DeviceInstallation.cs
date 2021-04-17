using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools
{
    /// <summary>
    /// Pour les notifications
    /// </summary>
    public class DeviceInstallation
    {
        /// <summary>
        /// installationId
        /// </summary>
        [JsonProperty("installationId")]
        public string InstallationId { get; set; }

        /// <summary>
        /// platform
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }
        /// <summary>
        /// pushChannel
        /// </summary>

        [JsonProperty("pushChannel")]
        public string PushChannel { get; set; }
        /// <summary>
        /// tags
        /// </summary>

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();
    }
}
