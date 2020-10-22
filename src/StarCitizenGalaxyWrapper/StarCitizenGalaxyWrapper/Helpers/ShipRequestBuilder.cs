using System.Collections.Generic;

namespace StarCitizenGalaxyWrapper.Helpers
{
    /// <summary>
    /// A helper class to build a configuration for the ships endpoint.
    /// </summary>
    public class ShipRequestBuilder
    {
        private readonly List<string> _chassis = new List<string>();
        private string _shipName;
        private int _page;
        private bool _doPagination;
        /// <summary>
        /// Adds the given chassis to the configuration.
        /// </summary>
        public ShipRequestBuilder AddChassis(string name)
        {
            _chassis.Add(name);
            return this;
        }

        /// <summary>
        /// Sets which name the requested ship has.
        /// </summary>
        public ShipRequestBuilder WithName(string name)
        {
            _shipName = name;
            return this;
        }

        /// <summary>
        /// Sets on which page the requested ship is.
        /// </summary>
        public ShipRequestBuilder WithPage(int page)
        {
            _page = page;
            return this;
        }

        /// <summary>
        /// Sets that pagination should be enabled.
        /// </summary>
        /// <returns></returns>
        public ShipRequestBuilder EnablePagination()
        {
            _doPagination = true;
            return this;
        }

        /// <summary>
        /// Builds the configuration for the API request.
        /// </summary>
        public ShipRequest Build()
        {
            return new ShipRequest(_chassis.ToArray(), _shipName, _page, _doPagination);
        }
    }
}
