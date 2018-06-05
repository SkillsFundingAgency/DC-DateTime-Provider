using System;
using System.Globalization;
using ESFA.DC.DateTime.Provider.Interface;

namespace ESFA.DC.DateTime.Provider
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        private static readonly IFormatProvider Culture = new CultureInfo("en-GB", true);

        private static readonly TimeZoneInfo UkTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

        public System.DateTime GetNowUtc()
        {
            return System.DateTime.UtcNow;
        }

        public System.DateTime ConvertUtcToUk(System.DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, UkTimeZone);
        }

        public System.DateTime ConvertOpaToDateTime(string opaDateTime)
        {
            return Convert.ToDateTime(opaDateTime, Culture);
        }
    }
}
