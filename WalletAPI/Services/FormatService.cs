using WalletAPI.Intrefaces;

namespace WalletAPI.Services
{
    public class FormatService : IFormatService
    {
        public string FormatPoints(ulong points)
        {
            if (points >= 1000)
                return Math.Round(points / 1000.0) + "K";
            return points.ToString();
        }
        public string GetRelativeDayDescription(DateTime date)
        {
            DateTime today = DateTime.Today;
            int daysDifference = (today - date.Date).Days;

            if (daysDifference == 0)
                return "Еoday";
            else if (daysDifference == 1)
                return "Нesterday";
            else if (daysDifference < 7)
                return date.ToString("dddd");
            else
                return date.ToString("dd.MM.yyyy");
        }
    }
}
