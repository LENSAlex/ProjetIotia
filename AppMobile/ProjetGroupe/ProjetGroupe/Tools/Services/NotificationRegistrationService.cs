using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Classe d'enregistrement au channel de notification 
    /// </summary>
    public class NotificationRegistrationService : INotificationRegistrationService
    {
        const string RequestUrl = "api/notifications/installations";
        const string CachedDeviceTokenKey = "cached_device_token";
        const string CachedTagsKey = "cached_tags";

        string _baseApiUrl;
        HttpClient _client;
        IDeviceInstallationService _deviceInstallationService;

        /// <summary>
        /// Enregistrement
        /// </summary>
        /// <param name="baseApiUri">url de l'api de notification</param>
        public NotificationRegistrationService(string baseApiUri)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");

            _baseApiUrl = baseApiUri;
        }
        /// <summary>
        /// DeviceInstallationService
        /// </summary>
        IDeviceInstallationService DeviceInstallationService
            => _deviceInstallationService ??
                (_deviceInstallationService = ServiceContainer.Resolve<IDeviceInstallationService>());

        /// <summary>
        /// Unregistrement du channel de notification
        /// </summary>
        /// <returns>task</returns>
        public async Task DeregisterDeviceAsync()
        {
            var cachedToken = await SecureStorage.GetAsync(CachedDeviceTokenKey)
                .ConfigureAwait(false);

            if (cachedToken == null)
                return;

            var deviceId = DeviceInstallationService?.GetDeviceId();

            if (string.IsNullOrWhiteSpace(deviceId))
                throw new Exception("Unable to resolve an ID for the device.");

            await SendAsync(HttpMethod.Delete, $"{RequestUrl}/{deviceId}")
                .ConfigureAwait(false);

            SecureStorage.Remove(CachedDeviceTokenKey);
            SecureStorage.Remove(CachedTagsKey);
        }
        /// <summary>
        /// Enregisterement de l'appreil au hub de notification
        /// </summary>
        /// <param name="tags">tags</param>
        /// <returns>task</returns>
        public async Task RegisterDeviceAsync(params string[] tags)
        {
            var deviceInstallation = DeviceInstallationService?.GetDeviceInstallation(tags);

            await SendAsync<DeviceInstallation>(HttpMethod.Put, RequestUrl, deviceInstallation)
                .ConfigureAwait(false);

            await SecureStorage.SetAsync(CachedDeviceTokenKey, deviceInstallation.PushChannel)
                .ConfigureAwait(false);

            await SecureStorage.SetAsync(CachedTagsKey, JsonConvert.SerializeObject(tags));
        }
        /// <summary>
        /// Refresh des appareils enregistrées
        /// </summary>
        /// <returns>task</returns>
        public async Task RefreshRegistrationAsync()
        {
            var cachedToken = await SecureStorage.GetAsync(CachedDeviceTokenKey)
                .ConfigureAwait(false);

            var serializedTags = await SecureStorage.GetAsync(CachedTagsKey)
                .ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(cachedToken) ||
                string.IsNullOrWhiteSpace(serializedTags) ||
                string.IsNullOrWhiteSpace(DeviceInstallationService.Token) ||
                cachedToken == DeviceInstallationService.Token)
                return;

            var tags = JsonConvert.DeserializeObject<string[]>(serializedTags);

            await RegisterDeviceAsync(tags);
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="requestType">requestType</param>
        /// <param name="requestUri">requestUri</param>
        /// <param name="obj">obj</param>
        /// <returns>task</returns>
        async Task SendAsync<T>(HttpMethod requestType, string requestUri, T obj)
        {
            string serializedContent = null;

            await Task.Run(() => serializedContent = JsonConvert.SerializeObject(obj))
                .ConfigureAwait(false);

            await SendAsync(requestType, requestUri, serializedContent);
        }
        /// <summary>
        /// SendAsync
        /// </summary>
        /// <param name="requestType">requestType</param>
        /// <param name="requestUri">requestUri</param>
        /// <param name="jsonRequest">jsonRequest</param>
        /// <returns>task</returns>
        async Task SendAsync(
            HttpMethod requestType,
            string requestUri,
            string jsonRequest = null)
        {
            var request = new HttpRequestMessage(requestType, new Uri($"{_baseApiUrl}{requestUri}"));

            if (jsonRequest != null)
                request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }
}
