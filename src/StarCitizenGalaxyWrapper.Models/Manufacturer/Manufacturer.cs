using System;

namespace StarCitizenGalaxyWrapper.Models.Manufacturer
{
    /// <summary>
    /// A representation of a single API response for the manufacturer endpoint.
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// The id of this manufacturer.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The name of this manufacturer.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The code of this manufacturer.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The datetime when this manufacturer was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The datetime when this manufacturer was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}