using System;
using StarCitizenGalaxyWrapper.Models.Ship.Roles;

namespace StarCitizenGalaxyWrapper.Models.Ship
{
    /// <summary>
    /// A representation of a single API response for the ship endpoint.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// The id of this ship.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The name of this ship.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The chassis of this ship.
        /// </summary>
        public Chassis.Chassis Chassis { get; set; }
        /// <summary>
        /// The ships this ship holds.
        /// </summary>
        public Ship[] HoldedShips { get; set; }
        /// <summary>
        /// The loaners of this ship,
        /// </summary>
        public string[] LoanerShips { get; set; }
        /// <summary>
        /// The height of this ship.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// The length of this ship.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// The beam of this ship.
        /// </summary>
        public int Beam { get; set; }
        /// <summary>
        /// The maximal crew amount of this ship.
        /// </summary>
        public int MaxCrew { get; set; }
        /// <summary>
        /// The minimal crew amount of this ship.
        /// </summary>
        public int MinCrew { get; set; }
        /// <summary>
        /// The production status of this ship.
        /// </summary>
        public string ReadyStatus { get; set; }
        /// <summary>
        /// The size of this ship.
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// The cargo capacity of this ship.
        /// </summary>
        public int CargoCapacity { get; set; }
        /// <summary>
        /// The career of this ship.
        /// </summary>
        public Career.Career Career { get; set; }
        /// <summary>
        /// The roles this ship has.
        /// </summary>
        public Role[] Roles { get; set; }
        /// <summary>
        /// The url of the pledge page of this ship.
        /// </summary>
        public string PledgeUrl { get; set; }
        /// <summary>
        /// The cost of this ship.
        /// </summary>
        public decimal PledgeCost { get; set; }
        /// <summary>
        /// The datetime this ship was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The datetime this ship was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
