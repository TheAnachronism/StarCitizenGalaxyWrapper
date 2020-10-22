using System;
using System.Collections.Generic;
using System.Text;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// A helper class to better configure a <see cref="ShipRequest"/>
    /// </summary>
    public class ShipRequestBuilder
    {
        private readonly List<string> _names = new List<string>();
        private readonly List<string> _ids = new List<string>();
        /// <summary>
        /// Adds the given names to the <see cref="ShipRequest"/>.
        /// </summary>
        public ShipRequestBuilder AddNames(IEnumerable<string> names)
        {
            _names.AddRange(names);
            return this;
        }
        /// <summary>
        /// Adds the given ids to the <see cref="ShipRequest"/>.
        /// </summary>
        public ShipRequestBuilder AddIds(IEnumerable<string> ids)
        {
            _ids.AddRange(ids);
            return this;
        }
        /// <summary>
        /// Builds the configured <see cref="ShipRequest"/>.
        /// </summary>
        public ShipRequest Build()
        {
            return new ShipRequest(_ids, _names);
        }
    }
}
