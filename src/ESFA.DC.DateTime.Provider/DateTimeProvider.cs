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

        public System.DateTime GetIlrFilenameDateTimeAsUtc(string ilrFilename)
        {
            string[] tokens = ilrFilename.Split('-');
            if (tokens.Length != 6)
            {
                throw new ArgumentException("ILR filename should be in the format ILR-LLLLLLLL-YYYY-yyyymmdd-hhmmss-NN.XML", nameof(ilrFilename));
            }

            System.DateTime localDateTime = System.DateTime.ParseExact(
                $"{tokens[3]}-{tokens[4]}",
                "yyyyMMdd-HHmmss",
                CultureInfo.InvariantCulture);

            System.DateTime ret = TimeZoneInfo.ConvertTimeToUtc(localDateTime, UkTimeZone);
            if (!ret.IsDaylightSavingTime() && System.DateTime.Now.IsDaylightSavingTime())
            {
                ret = ret.AddHours(1);
            }

            return ret;
        }
    }
}
