namespace WalletAPI.Services
{
    public class PointsService
    {
        public static string GetPoints()
        {
            Console.WriteLine(GetTimeOfYear(new DateTime(2024, 2, 2)));
            Console.WriteLine(GetTimeOfYear(new DateTime(2024, 5, 2)));
            Console.WriteLine(GetTimeOfYear(new DateTime(2024, 8, 2)));
            Console.WriteLine(GetTimeOfYear(new DateTime(2024, 10, 2)));


            DateTime date = DateTime.Now;

            int timeOfYear = GetTimeOfYear(date);
            int startMonth = 0;
            int startYear = 0;
            switch (timeOfYear)
            {
                case 0:
                    startMonth = 12;
                    startYear = date.Month == 12 ? date.Year : date.Year - 1;
                    break;
                case 1:
                    startMonth = 3;
                    startYear = date.Year;
                    break;
                case 2:
                    startMonth = 6;
                    startYear = date.Year;
                    break;
                case 3:
                    startMonth = 9;
                    startYear = date.Year;
                    break;
            }


            DateTime seasonStart = new DateTime(startYear, startMonth, 1);

            int dayOfSeason = (date - seasonStart).Days + 1;

            ulong points = 0;

            if (dayOfSeason == 1)
            {
                points = 2;
            }
            else if (dayOfSeason == 2)
            {
                points = 3;
            }
            else if (dayOfSeason > 2)
            {
                List<ulong> pointsList = new List<ulong> { 2, 3 };
                for (int i = 3; i <= dayOfSeason; i++)
                {
                    double temp = Math.Round(pointsList[i - 3] * 1.0 + pointsList[i - 2] * 0.6);
                    ulong newPoints = (ulong)Math.Round(temp);
                    pointsList.Add(newPoints);
                }
                points = pointsList[dayOfSeason - 1];
            }
            return FormatPoints(points);
        }
        /// <summary>
        /// Calculate index of time of year
        /// </summary>
        /// <returns>0 - winter, 1 - spring, 2 - summer, 3 - autumn</returns>
        private static int GetTimeOfYear(DateTime date)
        {
            int month = date.Month;
            return (month == 12 ? 0 : month) / 3;
        }
        private static string FormatPoints(ulong points)
        {
            if (points >= 1000)
            {
                return (points / 1000.0).ToString("0.#") + "K";
            }
            return points.ToString();
        }
    }
}
