using Microsoft.Extensions.DependencyInjection;
using StarCitizenGalaxyWrapper.Services;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// Extension for the <see cref="IServiceCollection"/> to use the <see cref="StarCitizenGalaxyClient"/>.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adds the <see cref="StarCitizenGalaxyClient"/> to the service collection.
        /// </summary>
        public static IServiceCollection AddStarCitizenGalaxyApiLibrary(this IServiceCollection services)
        {
            services.AddTransient<IStarCitizenGalaxyClient, StarCitizenGalaxyClient>();
            services.AddHttpClient<IHttpClientService, HttpClientService>();

            return services;
        }
    }
}
