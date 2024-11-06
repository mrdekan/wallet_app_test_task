using Wallet.Models.Entities;
using WalletAPI.Intrefaces;

namespace WalletAPI.Models.DTO
{
    public class Transaction
    {
        public Transaction(TransactionEntity entity, IFormatService formatService)
        {
            Id = entity.Id;
            Amount = Math.Round(entity.Amount, 2);
            Title = entity.Title;
            Description = entity.Description;
            Date = formatService.GetRelativeDayDescription(entity.Date.DateTime);
            IsPending = entity.IsPending;
            AuthorizedUser = entity.AuthorizedUser;
            Icon = entity.Icon;
            Type = entity.Type.ToString();
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public string Title { get; set; } = "Unknown";

        public string Description { get; set; } = string.Empty;

        public string Date { get; set; }

        public bool IsPending { get; set; }

        public string? AuthorizedUser { get; set; }

        public string Icon { get; set; } = string.Empty;
    }
}
