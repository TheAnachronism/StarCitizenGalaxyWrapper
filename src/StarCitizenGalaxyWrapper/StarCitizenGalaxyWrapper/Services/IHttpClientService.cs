using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StarCitizenGalaxyWrapper.Services
{
    /// <summary>
    /// Http client service which will handle sending http requests.
    /// </summary>
    public interface IHttpClientService
    {
        /// <summary>
        /// Sends a HttpGet request to the specified url.
        /// </summary>
        /// <param name="url">URL to send the request to.</param>
        /// <exception cref="HttpFailedRequestException">This exception will be thrown if you do not get a successful status code.</exception>
        Task<string> Get(string url);

        /// <summary>
        /// Sends a HttpGet request to the specified url and selects the "hydra-member" array.
        /// </summary>
        Task<string> GetHydraMember(string url);

        /// <summary>
        /// Sends a HttpPost request to the specified url with the given object as json body.
        /// </summary>
        Task<string> PostHydraMember(string url, object content);
    }

    /// <summary>
    /// Default implementation of <see cref="IHttpClientService"/>.
    /// </summary>
    class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> Get(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if(!response.IsSuccessStatusCode)
                throw new HttpFailedRequestException(response.StatusCode, response.ReasonPhrase, url);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetHydraMember(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var objectJson = JObject.Parse(content)["hydra:member"];

            return objectJson!.ToString();
        }

        public async Task<string> PostHydraMember(string url, object content)
        {
            var contentAsJson = JsonConvert.SerializeObject(content);
            var response = await _httpClient.PostAsync(url,
                new StringContent(contentAsJson, Encoding.UTF8, "application/json"));

            var responseContent = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseContent)["hydra:member"]!.ToString();
        }
    }

    /// <summary>
    /// Custom exception for when a request does not return a successful response.
    /// </summary>
    class HttpFailedRequestException : Exception
    {
        public HttpFailedRequestException(HttpStatusCode statusCode, string reasonPhrase, string url)
            : this(GenerateGetException(statusCode, reasonPhrase, url))
        {
        }

        public HttpFailedRequestException(string message) : base(message)
        {
        }

        private static string GenerateGetException(HttpStatusCode statusCode, string reasonPhrase, string url)
        {
            return $"Status Code: {(int)statusCode} - Reason Phrase: {reasonPhrase} : URL: {url}";
        }
    }
}
