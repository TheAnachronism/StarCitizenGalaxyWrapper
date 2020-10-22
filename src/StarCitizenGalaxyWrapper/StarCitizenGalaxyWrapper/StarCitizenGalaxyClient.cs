using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
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
        /// Sends an API request to get all chassis.
        /// </summary>
        Task<IEnumerable<Chassis>> GetChassis();
        /// <summary>
        /// Sends an API request for the chassis with the given id.
        /// </summary>
        /// <param name="id">The id of the chassis.</param>
        /// <returns>An instance of <see cref="Chassis"/> containing the information about the requested chassis.</returns>
        Task<Chassis> GetChassis(string id);
        /// <summary>
        /// Sends an API request to get all manufacturers.
        /// </summary>
        Task<IEnumerable<Manufacturer>> GetManufacturers();
        /// <summary>
        /// Sends an API request for the manufacturer with the given id.
        /// </summary>
        /// <param name="id">The id of the manufacturer.</param>
        /// <returns>An instance of <see cref="Manufacturer"/> containing the information about the request manufacturer.</returns>
        Task<Manufacturer> GetManufacturer(string id);
        /// <summary>
        /// Sends an API request to get all ship careers.
        /// </summary>
        Task<IEnumerable<Career>> GetCareers();
        /// <summary>
        /// Sends an API request for the ship career with the given id.
        /// </summary>
        /// <param name="id">The id of the ship career.</param>
        /// <returns>An instance of <see cref="Career"/> containing the information about the request career.</returns>
        Task<Career> GetCareer(string id);
        /// <summary>
        /// Sends an API request to get all ship roles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Role>> GetRoles();
        /// <summary>
        /// Sends an API request for the ship role with the given id.
        /// </summary>
        /// <param name="id">The id of the ship role.</param>
        /// <returns>An instance of <see cref="Role"/> containing the information about the requested ship role.</returns>
        Task<Role> GetRole(string id);
        /// <summary>
        /// Sends an API request to get all ships.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ship>> GetShips();
        /// <summary>
        /// Sends an API request for the ship with the given id.
        /// </summary>
        /// <param name="id">The id of the ship.</param>
        /// <returns>An instance of <see cref="Ship"/> containing the information about the requested ship.</returns>
        Task<Ship> GetShip(string id);
        /// <summary>
        /// Sends an API request for the specified ship configured in the given request.
        /// </summary>
        /// <param name="request">The <see cref="ShipRequest"/> which has the requested information configured.</param>
        /// <returns>A list of <see cref="Ship"/>s containing the information of the requested ships.</returns>
        Task<IEnumerable<Ship>> GetShipsBulk(ShipRequest request);
    }

    /// <inheritdoc cref="IStarCitizenGalaxyClient"/>.
    internal class StarCitizenGalaxyClient : IStarCitizenGalaxyClient
    {
        private readonly IHttpClientService _httpService;

        public StarCitizenGalaxyClient(IHttpClientService httpService)
        {
            _httpService = httpService;
        }

        public Task<IEnumerable<Chassis>> GetChassis()
        {
            throw new System.NotImplementedException();
        }

        public Task<Chassis> GetChassis(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            throw new System.NotImplementedException();
        }

        public Task<Manufacturer> GetManufacturer(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Career>> GetCareers()
        {
            throw new System.NotImplementedException();
        }

        public Task<Career> GetCareer(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRoles()
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> GetRole(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Ship>> GetShips()
        {
            throw new System.NotImplementedException();
        }

        public Task<Ship> GetShip(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Ship>> GetShipsBulk(ShipRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
