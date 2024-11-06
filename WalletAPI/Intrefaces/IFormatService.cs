namespace WalletAPI.Intrefaces
{
    public interface IFormatService
    {
        string FormatPoints(ulong points);
        string GetRelativeDayDescription(DateTime date);
    }
}
