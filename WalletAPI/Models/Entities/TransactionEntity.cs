using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Models.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity()
        {

        }
        [Key]
        public int Id { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = "Unknown";

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column("Date", TypeName = "timestamp with time zone")]
        public DateTimeOffset Date { get; set; }

        public bool IsPending { get; set; }

        [MaxLength(100)]
        public string? AuthorizedUser { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
    }

    public enum TransactionType
    {
        Payment,
        Credit
    }
}
