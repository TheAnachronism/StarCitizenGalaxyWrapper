using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarCitizenGalaxyWrapper.Helpers;
using StarCitizenGalaxyWrapper.Models.Chassis;
using StarCitizenGalaxyWrapper.Models.Manufacturer;
using StarCitizenGalaxyWrapper.Models.Ship;
using StarCitizenGalaxyWrapper.Models.Ship.Career;
using StarCitizenGalaxyWrapper.Models.Ship.Roles;
using StarCitizenGalaxyWrapper.Services;

namespace StarCitizenGalaxyWrapper
{    
    /// <summary>
    /// Client to connect to the Star Citizen Galaxy API.
    /// </summary>
    public interface IStarCitizenGalaxyClient
    {
        /// <summary>
        /// Sends an API bulkRequest to get all chassis.
        /// </summary>
        Task<IEnumerable<Chassis>> GetChassis();
        /// <summary>
        /// Sends an API bulkRequest for the chassis with the given id.
        /// </summary>
        /// <param name="id">The id of the chassis.</param>
        /// <returns>An instance of <see cref="Chassis"/> containing the information about the requested chassis.</returns>
        Task<Chassis> GetChassis(string id);
        /// <summary>
        /// Sends an API bulkRequest to get all manufacturers.
        /// </summary>
        Task<IEnumerable<Manufacturer>> GetManufacturers();
        /// <summary>
        /// Sends an API bulkRequest for the manufacturer with the given id.
        /// </summary>
        /// <param name="id">The id of the manufacturer.</param>
        /// <returns>An instance of <see cref="Manufacturer"/> containing the information about the bulkRequest manufacturer.</returns>
        Task<Manufacturer> GetManufacturer(string id);
        /// <summary>
        /// Sends an API bulkRequest to get all ship careers.
        /// </summary>
        Task<IEnumerable<Career>> GetCareers();
        /// <summary>
        /// Sends an API bulkRequest for the ship career with the given id.
        /// </summary>
        /// <param name="id">The id of the ship career.</param>
        /// <returns>An instance of <see cref="Career"/> containing the information about the bulkRequest career.</returns>
        Task<Career> GetCareer(string id);
        /// <summary>
        /// Sends an API bulkRequest to get all ship roles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Role>> GetRoles();
        /// <summary>
        /// Sends an API bulkRequest for the ship role with the given id.
        /// </summary>
        /// <param name="id">The id of the ship role.</param>
        /// <returns>An instance of <see cref="Role"/> containing the information about the requested ship role.</returns>
        Task<Role> GetRole(string id);
        /// <summary>
        /// Sends an API bulkRequest to get all ships.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ship>> GetShips(ShipRequest request);
        /// <summary>
        /// Sends an API bulkRequest for the ship with the given id.
        /// </summary>
        /// <param name="id">The id of the ship.</param>
        /// <returns>An instance of <see cref="Ship"/> containing the information about the requested ship.</returns>
        Task<Ship> GetShip(string id);
        /// <summary>
        /// Sends an API bulkRequest for the specified ship configured in the given bulkRequest.
        /// </summary>
        /// <param name="bulkRequest">The <see cref="ShipBulkRequest"/> which has the requested information configured.</param>
        /// <returns>A list of <see cref="Ship"/>s containing the information of the requested ships.</returns>
        Task<IEnumerable<Ship>> GetShipsBulk(ShipBulkRequest bulkRequest);
    }

    /// <inheritdoc cref="IStarCitizenGalaxyClient"/>.
    internal class StarCitizenGalaxyClient : IStarCitizenGalaxyClient
    {
        private readonly IHttpClientService _httpService;
        private const string ApiRequestUrl = "https://sc-galaxy.com/api/{0}";

        public StarCitizenGalaxyClient(IHttpClientService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Chassis>> GetChassis()
        {
            var requestUrl = string.Format(ApiRequestUrl, "chassis");
            var content = await _httpService.GetHydraMember(requestUrl);
            
            return JsonConvert.DeserializeObject<List<Chassis>>(content);
        }

        public async Task<Chassis> GetChassis(string id)
        {
            var requestUrl = string.Format(ApiRequestUrl, $"chassis/{id}");
            var content = await _httpService.Get(requestUrl);

            return JsonConvert.DeserializeObject<Chassis>(content);
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            var requestUrl = string.Format(ApiRequestUrl, "manufacturers");
            var content = await _httpService.GetHydraMember(requestUrl);
            
            return JsonConvert.DeserializeObject<List<Manufacturer>>(content);
        }

        public async Task<Manufacturer> GetManufacturer(string id)
        {
            var requestUrl = string.Format(ApiRequestUrl, $"manufacturers/{id}");
            var content = await _httpService.Get(requestUrl);

            return JsonConvert.DeserializeObject<Manufacturer>(content);
        }

        public async Task<IEnumerable<Career>> GetCareers()
        {
            var requestUrl = string.Format(ApiRequestUrl, "ship-careers");
            var content = await _httpService.GetHydraMember(requestUrl);
            
            return JsonConvert.DeserializeObject<List<Career>>(content);
        }

        public async Task<Career> GetCareer(string id)
        {
            var requestUrl = string.Format(ApiRequestUrl, $"ship-careers/{id}");
            var content = await _httpService.Get(requestUrl);

            return JsonConvert.DeserializeObject<Career>(content);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var requestUrl = string.Format(ApiRequestUrl, "ship-roles");
            var content = await _httpService.GetHydraMember(requestUrl);

            return JsonConvert.DeserializeObject<List<Role>>(content);
        }

        public async Task<Role> GetRole(string id)
        {
            var requestUrl = string.Format(ApiRequestUrl, $"ship-roles/{id}");
            var content = await _httpService.Get(requestUrl);

            return JsonConvert.DeserializeObject<Role>(content);
        }

        public async Task<IEnumerable<Ship>> GetShips(ShipRequest request)
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (request.Chassis.Any())
                parameters.AddRange(request.Chassis.Select(x => new KeyValuePair<string, string>("chassis[]", x)));
            if (!string.IsNullOrEmpty(request.Name))
                parameters.Add(new KeyValuePair<string, string>("name", request.Name));
            if (request.Page != 0)
                parameters.Add(new KeyValuePair<string, string>("page", request.Page.ToString()));
            if (request.Pagination)
                parameters.Add(new KeyValuePair<string, string>("pagination", "true"));

            var requestUrl = $"{string.Format(ApiRequestUrl, "ships")}?{string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"))}";

            var content = await _httpService.GetHydraMember(requestUrl);
            
            return JsonConvert.DeserializeObject<List<Ship>>(content);
        }

        public async Task<Ship> GetShip(string id)
        {
            var requestUrl = string.Format(ApiRequestUrl, $"ships/{id}");
            var content = await _httpService.Get(requestUrl);

            return JsonConvert.DeserializeObject<Ship>(content);
        }

        public async Task<IEnumerable<Ship>> GetShipsBulk(ShipBulkRequest bulkRequest)
        {
            var requestUrl = string.Format(ApiRequestUrl, "ships/bulk");
            var content = await _httpService.PostHydraMember(requestUrl, bulkRequest);

            return JsonConvert.DeserializeObject<List<Ship>>(content);
        }
    }
}
