using System.Collections.Generic;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// A request to configure which ships should be requested from the ships/bulk endpoint.
    /// Keep in mind, that both fields can be set so only a name or an id of the requested ship must be entered.
    /// </summary>
    public class ShipRequest
    {
        /// <summary>
        /// Creates a new instance of <see cref="ShipRequest"/> with the given ids and names.
        /// </summary>
        internal ShipRequest(List<string> ids, List<string> names)
        {
            Ids = ids;
            Names = names;
        }

        /// <summary>
        /// The ids of the ships requested.
        /// </summary>
        public List<string> Ids { get; }
        /// <summary>
        /// The names of the ships request.
        /// </summary>
        public List<string> Names { get; }
    }
}
