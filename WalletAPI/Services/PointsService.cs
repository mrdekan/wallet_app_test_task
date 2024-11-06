using WalletAPI.Intrefaces;

namespace WalletAPI.Services
{
    public class PointsService : IPointsService
    {
        public ulong GetPoints(DateTime date)
        {
            int timeOfYear = GetTimeOfYear(date);
            int startMonth = timeOfYear == 0 ? 12 : timeOfYear * 3;
            int startYear = date.Month == 12 ? date.Year : date.Year - 1;

            DateTime seasonStart = new(startYear, startMonth, 1);

            int dayOfSeason = (date - seasonStart).Days + 1;

            if (dayOfSeason > 2)
            {
                ulong theDayBeforeYeasterday = 2;
                ulong yesterday = 3;
                for (int i = 3; i <= dayOfSeason; i++)
                {
                    ulong newPoints = (ulong)Math.Round(theDayBeforeYeasterday + yesterday * 0.6);
                    theDayBeforeYeasterday = yesterday;
                    yesterday = newPoints;
                }
                return yesterday;
            }
            else
                return (ulong)dayOfSeason + 1; // 1 day - 2 points, 2 day - 3 points
        }
        /// <summary>
        /// Calculate index of time of year
        /// </summary>
        /// <returns>0 - winter, 1 - spring, 2 - summer, 3 - autumn</returns>
        private int GetTimeOfYear(DateTime date)
        {
            int month = date.Month;
            return (month == 12 ? 0 : month) / 3;
        }
    }
}
