using Microsoft.AspNetCore.Mvc;
using Wallet.Intrefaces;
using Wallet.Models.Entities;

namespace Wallet.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;
        public TransactionsController(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        [HttpGet("recent")]
        public async Task<IActionResult> GetLastTransactions()
        {
            List<TransactionEntity> res = await _transactionsRepository.GetLastTransactions(10);
            return Ok(new { Transactions = res });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(string id)
        {
            bool parsed = int.TryParse(id, out int parsedId);
            if (!parsed) return BadRequest();
            TransactionEntity? res = await _transactionsRepository.GetById(parsedId);
            if (res == null) return NotFound();
            return Ok(new { Transaction = res });
        }
    }
}
