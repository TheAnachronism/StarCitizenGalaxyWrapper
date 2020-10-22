using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StarCitizenGalaxyWrapper;
using StarCitizenGalaxyWrapper.Helpers;

namespace APITesting
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var services = new ServiceCollection()
                .AddStarCitizenGalaxyApiLibrary()
                .BuildServiceProvider();

            var client = services.GetService<IStarCitizenGalaxyClient>();
            var result = (await client.GetLoanerShips(""));
        }
    }
}
