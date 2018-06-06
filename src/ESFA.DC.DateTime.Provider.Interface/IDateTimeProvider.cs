using System;

namespace ESFA.DC.DateTime.Provider.Interface
{
    public interface IDateTimeProvider
    {
        System.DateTime GetNowUtc();

        System.DateTime ConvertUtcToUk(System.DateTime utcDateTime);

        System.DateTime ConvertUkToUtc(string dateTime, string format = "yyyyMMdd-HHmmss");

        System.DateTime ConvertOpaToDateTime(string opaDateTime);
    }
}
