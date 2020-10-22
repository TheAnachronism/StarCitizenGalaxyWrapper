using System;
using System.Collections.Generic;
using System.Text;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// A configuration for the ships endpoint.
    /// </summary>
    public class ShipRequest
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ShipRequest"/>/
        /// </summary>
        public ShipRequest(string[] chassis, string name, int page, bool pagination)
        {
            Chassis = chassis;
            Name = name;
            Page = page;
            Pagination = pagination;
        }

        /// <summary>
        /// The different chassis the requested ships should have.
        /// </summary>
        public string[] Chassis { get; }
        /// <summary>
        /// The name of the requested ships.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The page on which the requested ships are.
        /// </summary>
        public int Page { get; }
        /// <summary>
        /// If pagination should be enabled.
        /// </summary>
        public bool Pagination { get; }
    }
}
