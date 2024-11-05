using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDailyPoints()
        {
            return Ok();
        }
    }
}
