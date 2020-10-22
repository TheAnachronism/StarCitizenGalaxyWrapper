using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// A request to configure which ships should be requested from the ships/bulk endpoint.
    /// Keep in mind, that both fields can be set so only a name or an id of the requested ship must be entered.
    /// </summary>
    public class ShipBulkRequest
    {
        /// <summary>
        /// Creates a new instance of <see cref="ShipBulkRequest"/> with the given ids and names.
        /// </summary>
        internal ShipBulkRequest(List<string> ids, List<string> names)
        {
            Ids = ids;
            Names = names;
        }

        /// <summary>
        /// The ids of the ships requested.
        /// </summary>
        [JsonProperty("ids")]
        public List<string> Ids { get; }
        /// <summary>
        /// The names of the ships request.
        /// </summary>
        [JsonProperty("names")]
        public List<string> Names { get; }
    }
}
