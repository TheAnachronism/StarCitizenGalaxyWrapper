using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
