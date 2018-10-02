using System;

namespace ESFA.DC.DateTimeProvider.Interface
{
    public interface IDateTimeProvider
    {
        DateTime GetNowUtc();

        DateTime ConvertUtcToUk(DateTime utcDateTime);

        DateTime ConvertUkToUtc(DateTime ukDateTime);

        DateTime ConvertUkToUtc(string ukDateTime, string format = "yyyyMMdd-HHmmss");
    }
}
