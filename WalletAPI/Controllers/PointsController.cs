using Microsoft.AspNetCore.Mvc;
using WalletAPI.Services;

namespace Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDailyPoints()
        {
            return Ok(new { Points = PointsService.GetPoints() });
        }
    }
}
