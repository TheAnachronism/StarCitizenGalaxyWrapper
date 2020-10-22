using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
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

            var jsonObject = JArray.Parse(content);
            var ships = new List<Ship>();
            ships.AddRange(jsonObject.Select(ParseShip));

            return ships;
        }

        public async Task<Ship> GetShip(string id)
        {
            var requestUrl = string.Format(ApiRequestUrl, $"ships/{id}");
            var content = await _httpService.Get(requestUrl);

            return JsonConvert.DeserializeObject<Ship>(content);
        }

        public Task<IEnumerable<Ship>> GetLoanerShips(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ship>> GetHoldedShips(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ship>> GetShipsBulk(ShipBulkRequest request)
        {
            var requestUrl = string.Format(ApiRequestUrl, "ships/bulk");
            var content = await _httpService.PostHydraMember(requestUrl, request);

            var jsonObject = JArray.Parse(content);
            var ships = new List<Ship>();
            ships.AddRange(jsonObject.Select(ParseShip));

            return ships;
        }

        private Ship ParseShip(JToken shipJson)
        {
            var ship = JsonConvert.DeserializeObject<Ship>(shipJson.ToString());

            var loanerShips = new List<Ship>();

            if (shipJson["loanerShips"] is JArray loanerJson)
                loanerShips.AddRange(loanerJson.Select(loanerJsonObject => loanerJsonObject["loaned"])
                    .Select(loaner => JsonConvert.DeserializeObject<Ship>(loaner!.ToString())));

            ship.LoanerShips = loanerShips.ToArray();

            var holdedShips = new List<Ship>();

            if (shipJson["holdedShips"] is JArray holdedJson)
                holdedShips.AddRange(holdedJson.Select(holdedJsonObject => holdedJsonObject["holded"])
                    .Select(holded => JsonConvert.DeserializeObject<Ship>(holded!.ToString())));

            ship.HoldedShips = holdedShips.ToArray();

            return ship;
        }
    }
}
