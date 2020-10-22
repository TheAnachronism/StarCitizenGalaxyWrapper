using System;

namespace StarCitizenGalaxyWrapper.Models.Chassis
{
    /// <summary>
    /// A representation of a single API response for the chassis endpoint.
    /// </summary>
    public class Chassis
    {
        /// <summary>
        /// The id of this chassis.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The name of this chassis.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The <see cref="Manufacturer"/> of this chassis.
        /// </summary>
        public Manufacturer.Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// The datetime this chassis was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The datetime this chassis was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
