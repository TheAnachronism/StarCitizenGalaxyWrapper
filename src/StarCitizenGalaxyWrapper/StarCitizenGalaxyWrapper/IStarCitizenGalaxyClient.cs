using System.Collections.Generic;
using System.Threading.Tasks;
using StarCitizenGalaxyWrapper.Helpers;
using StarCitizenGalaxyWrapper.Models.Chassis;
using StarCitizenGalaxyWrapper.Models.Manufacturer;
using StarCitizenGalaxyWrapper.Models.Ship;
using StarCitizenGalaxyWrapper.Models.Ship.Career;
using StarCitizenGalaxyWrapper.Models.Ship.Roles;

namespace StarCitizenGalaxyWrapper
{
    /// <summary>
    /// Client to connect to the Star Citizen Galaxy API.
    /// </summary>
    public interface IStarCitizenGalaxyClient
    {
        /// <summary>
        /// Sends an API Request to get all chassis.
        /// </summary>
        Task<IEnumerable<Chassis>> GetChassis();
        /// <summary>
        /// Sends an API Request for the chassis with the given id.
        /// </summary>
        /// <param name="id">The id of the chassis.</param>
        /// <returns>An instance of <see cref="Chassis"/> containing the information about the requested chassis.</returns>
        Task<Chassis> GetChassis(string id);
        /// <summary>
        /// Sends an API Request to get all manufacturers.
        /// </summary>
        Task<IEnumerable<Manufacturer>> GetManufacturers();
        /// <summary>
        /// Sends an API Request for the manufacturer with the given id.
        /// </summary>
        /// <param name="id">The id of the manufacturer.</param>
        /// <returns>An instance of <see cref="Manufacturer"/> containing the information about the Request manufacturer.</returns>
        Task<Manufacturer> GetManufacturer(string id);
        /// <summary>
        /// Sends an API Request to get all ship careers.
        /// </summary>
        Task<IEnumerable<Career>> GetCareers();
        /// <summary>
        /// Sends an API Request for the ship career with the given id.
        /// </summary>
        /// <param name="id">The id of the ship career.</param>
        /// <returns>An instance of <see cref="Career"/> containing the information about the Request career.</returns>
        Task<Career> GetCareer(string id);
        /// <summary>
        /// Sends an API Request to get all ship roles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Role>> GetRoles();
        /// <summary>
        /// Sends an API Request for the ship role with the given id.
        /// </summary>
        /// <param name="id">The id of the ship role.</param>
        /// <returns>An instance of <see cref="Role"/> containing the information about the requested ship role.</returns>
        Task<Role> GetRole(string id);
        /// <summary>
        /// Sends an API Request to get all ships.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ship>> GetShips(ShipRequest request);
        /// <summary>
        /// Sends an API Request for the ship with the given id.
        /// </summary>
        /// <param name="id">The id of the ship.</param>
        /// <returns>An instance of <see cref="Ship"/> containing the information about the requested ship.</returns>
        Task<Ship> GetShip(string id);
        /// <summary>
        /// Sends an API request to get the loaner ships for the ship with the specified id.
        /// </summary>
        /// <param name="id">The id of the ship to get the loaners from.</param>
        /// <returns>An list of instance of <see cref="Ship"/> containing the information of the loaners.</returns>
        Task<IEnumerable<Ship>> GetLoanerShips(string id);
        /// <summary>
        /// Sends an API request to get the holded ships from the ship with the specified id.
        /// </summary>
        /// <param name="id">The id of the ship to get the holded ships from.</param>
        /// <returns>A list of instances of <see cref="Ship"/> containing the information of the holded ships.</returns>
        Task<IEnumerable<Ship>> GetHoldedShips(string id);
        /// <summary>
        /// Sends an API Request for the specified ship configured in the given Request.
        /// </summary>
        /// <param name="request">The <see cref="ShipRequest"/> which has the requested information configured.</param>
        /// <returns>A list of <see cref="Ship"/>s containing the information of the requested ships.</returns>
        Task<IEnumerable<Ship>> GetShipsBulk(ShipBulkRequest request);
    }
}