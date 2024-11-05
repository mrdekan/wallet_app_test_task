using Wallet.Models.Entities;

namespace Wallet.Intrefaces
{
    public interface ITransactionsRepository
    {
        Task<List<TransactionEntity>> GetAllTransactions();
        Task<List<TransactionEntity>> GetLastTransactions(int count);
        Task<TransactionEntity?> GetById(int id);
    }
}
