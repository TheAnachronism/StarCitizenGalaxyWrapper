using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCitizenGalaxyWrapper;

namespace AspNetCore_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStarCitizenGalaxyClient _galaxyClient;
        public HomeController(IStarCitizenGalaxyClient galaxyClient)
        {
            _galaxyClient = galaxyClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Example request for all chassis
            var result = await _galaxyClient.GetChassis();
            return Ok(result);
        }
    }
}
