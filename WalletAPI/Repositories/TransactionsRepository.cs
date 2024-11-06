using Microsoft.EntityFrameworkCore;
using Wallet.Data;
using Wallet.Intrefaces;
using Wallet.Models.Entities;

namespace Wallet.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly WalletDbContext _dbContext;
        public TransactionsRepository(WalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TransactionEntity>> GetAllTransactions()
        {
            return await _dbContext.Transactions.OrderByDescending(t => t.Date).ToListAsync();
        }

        public async Task<TransactionEntity?> GetById(int id)
        {
            return await _dbContext.Transactions
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TransactionEntity>> GetLastTransactions(int count)
        {
            return await _dbContext.Transactions
                .OrderByDescending(t => t.Date)
                .Take(count)
                .ToListAsync();
        }
    }
}
