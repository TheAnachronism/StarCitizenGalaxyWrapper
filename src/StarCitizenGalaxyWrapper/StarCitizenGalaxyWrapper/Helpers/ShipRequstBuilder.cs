using System;
using System.Collections.Generic;
using System.Text;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// A helper class to better configure a <see cref="ShipBulkRequest"/>
    /// </summary>
    public class ShipBulkRequestBuilder
    {
        private readonly List<string> _names = new List<string>();
        private readonly List<string> _ids = new List<string>();
        /// <summary>
        /// Adds the given names to the <see cref="ShipBulkRequest"/>.
        /// </summary>
        public ShipBulkRequestBuilder AddNames(IEnumerable<string> names)
        {
            _names.AddRange(names);
            return this;
        }
        /// <summary>
        /// Adds the given ids to the <see cref="ShipBulkRequest"/>.
        /// </summary>
        public ShipBulkRequestBuilder AddIds(IEnumerable<string> ids)
        {
            _ids.AddRange(ids);
            return this;
        }
        /// <summary>
        /// Builds the configured <see cref="ShipBulkRequest"/>.
        /// </summary>
        public ShipBulkRequest Build()
        {
            return new ShipBulkRequest(_ids, _names);
        }
    }
}
