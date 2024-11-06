using Microsoft.AspNetCore.Mvc;
using Wallet.Intrefaces;
using Wallet.Models.Entities;
using WalletAPI.Intrefaces;
using WalletAPI.Models.DTO;

namespace Wallet.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IFormatService _formatService;
        public TransactionsController(ITransactionsRepository transactionsRepository, IFormatService formatService)
        {
            _transactionsRepository = transactionsRepository;
            _formatService = formatService;
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetLastTransactions()
        {
            List<TransactionEntity> res = await _transactionsRepository.GetLastTransactions(10);
            return Ok(new { Transactions = res.Select(el => new Transaction(el, _formatService)) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(string id)
        {
            bool parsed = int.TryParse(id, out int parsedId);
            if (!parsed) return BadRequest();
            TransactionEntity? res = await _transactionsRepository.GetById(parsedId);
            if (res == null) return NotFound();
            return Ok(new { Transaction = new Transaction(res, _formatService) });
        }
    }
}
