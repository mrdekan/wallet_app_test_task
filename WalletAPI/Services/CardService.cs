using WalletAPI.Intrefaces;

namespace WalletAPI.Services
{
    public class CardService : ICardService
    {
        public decimal GetCardBalance() =>
            (decimal)(new Random().NextDouble() * 1500);
    }
}
