using System;

namespace ESFA.DC.DateTimeProvider.Interface
{
    public interface IDateTimeProvider
    {
        DateTime GetNowUtc();

        DateTime ConvertUtcToUk(DateTime utcDateTime);

        DateTime ConvertUkToUtc(string dateTime, string format = "yyyyMMdd-HHmmss");
    }
}
