using StarCitizenGalaxyWrapper.Services;

namespace StarCitizenGalaxyWrapper
{    
    /// <summary>
    /// Client to connect to the Star Citizen Galaxy API.
    /// </summary>
    public interface IStarCitizenGalaxyClient
    {
        
    }

    /// <inheritdoc cref="IStarCitizenGalaxyClient"/>.
    internal class StarCitizenGalaxyClient : IStarCitizenGalaxyClient
    {
        private readonly IHttpClientService _httpService;

        public StarCitizenGalaxyClient(IHttpClientService httpService)
        {
            _httpService = httpService;
        }
    }
}
