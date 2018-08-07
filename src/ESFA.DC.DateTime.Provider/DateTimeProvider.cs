using System;
using System.Globalization;
using ESFA.DC.DateTimeProvider.Interface;

namespace ESFA.DC.DateTimeProvider
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        private static readonly TimeZoneInfo UkTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

        public DateTime GetNowUtc()
        {
            return DateTime.UtcNow;
        }

        public DateTime ConvertUtcToUk(DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, UkTimeZone);
        }

        public DateTime ConvertUkToUtc(string dateTime, string format = "yyyyMMdd-HHmmss")
        {
            DateTime localDateTime = DateTime.ParseExact(dateTime, format, CultureInfo.InvariantCulture);
            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, UkTimeZone);
        }
    }
}
