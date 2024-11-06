using Microsoft.AspNetCore.Mvc;
using WalletAPI.Intrefaces;

namespace Wallet.Controllers
{
    [Route("api/wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IPointsService _pointsService;
        private readonly IFormatService _formatService;
        private readonly ICardService _cardService;
        public WalletController(IPointsService pointsService, IFormatService formatService, ICardService cardService)
        {
            _pointsService = pointsService;
            _formatService = formatService;
            _cardService = cardService;
        }

        [HttpGet("getDailyPoints")]
        public IActionResult GetDailyPoints()
        {
            return Ok(new { Points = _formatService.FormatPoints(_pointsService.GetPoints(DateTime.Now)) });
        }

        [HttpGet("getBalance")]
        public IActionResult GetBalance()
        {
            decimal balance = _cardService.GetCardBalance();
            return Ok(new { Balance = Math.Round(balance, 2), Available = Math.Round(1500 - balance, 2) });
        }

        [HttpGet("getPaymentDue")]
        public IActionResult GetPaymentDue()
        {
            string monthName = DateTime.Now.ToString("MMMM");
            return Ok(new { Message = $"You’ve paid your {monthName} balance." });
        }
    }
}
