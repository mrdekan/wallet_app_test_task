using Microsoft.EntityFrameworkCore;
using Wallet.Models.Entities;

namespace Wallet.Data
{
    public class WalletDbContext : DbContext
    {
        static WalletDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options) { }
        public DbSet<TransactionEntity> Transactions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        //    base.OnModelCreating(modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>().HasData(
                new TransactionEntity { Id = 1, Type = TransactionType.Payment, Amount = 50.75m, Title = "IKEA", Description = "Home furniture purchase", Date = new DateTimeOffset(DateTime.Now.AddDays(-1)), IsPending = false, AuthorizedUser = null, Icon = "icon1" },
                new TransactionEntity { Id = 2, Type = TransactionType.Credit, Amount = 20.00m, Title = "Target", Description = "Grocery shopping", Date = new DateTimeOffset(DateTime.Now.AddDays(-2)), IsPending = true, AuthorizedUser = "Alice", Icon = "icon2" },
                new TransactionEntity { Id = 3, Type = TransactionType.Payment, Amount = 120.00m, Title = "Spotify", Description = "Monthly subscription", Date = new DateTimeOffset(DateTime.Now.AddDays(-3)), IsPending = false, AuthorizedUser = "Bob", Icon = "icon3" },
                new TransactionEntity { Id = 4, Type = TransactionType.Credit, Amount = 35.00m, Title = "Amazon", Description = "Online order", Date = new DateTimeOffset(DateTime.Now.AddDays(-4)), IsPending = false, AuthorizedUser = null, Icon = "icon4" },
                new TransactionEntity { Id = 5, Type = TransactionType.Payment, Amount = 75.50m, Title = "Walmart", Description = "Shopping for home essentials", Date = new DateTimeOffset(DateTime.Now.AddDays(-5)), IsPending = false, AuthorizedUser = null, Icon = "icon5" },
                new TransactionEntity { Id = 6, Type = TransactionType.Credit, Amount = 15.00m, Title = "Uber", Description = "Ride to office", Date = new DateTimeOffset(DateTime.Now.AddDays(-6)), IsPending = false, AuthorizedUser = "Charlie", Icon = "icon6" },
                new TransactionEntity { Id = 7, Type = TransactionType.Payment, Amount = 45.25m, Title = "Apple", Description = "App purchase", Date = new DateTimeOffset(DateTime.Now.AddDays(-7)), IsPending = false, AuthorizedUser = null, Icon = "icon7" },
                new TransactionEntity { Id = 8, Type = TransactionType.Credit, Amount = 100.00m, Title = "Netflix", Description = "Annual subscription", Date = new DateTimeOffset(DateTime.Now.AddDays(-8)), IsPending = false, AuthorizedUser = "David", Icon = "icon8" },
                new TransactionEntity { Id = 9, Type = TransactionType.Payment, Amount = 60.00m, Title = "Starbucks", Description = "Coffee with friends", Date = new DateTimeOffset(DateTime.Now.AddDays(-8)), IsPending = true, AuthorizedUser = null, Icon = "icon9" },
                new TransactionEntity { Id = 10, Type = TransactionType.Credit, Amount = 250.00m, Title = "Best Buy", Description = "New headphones", Date = new DateTimeOffset(DateTime.Now.AddDays(-8)), IsPending = false, AuthorizedUser = "Emma", Icon = "icon10" }
            );
        }
    }
}
