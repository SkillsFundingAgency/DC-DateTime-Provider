using System;
using ESFA.DC.DateTime.Provider.Interface;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.DateTime.Provider.Tests
{
    public sealed class DateTimeProviderTests
    {
        [Fact]
        public void TestGetNowUtc()
        {
            //IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            //dateTimeProvider.GetNowUtc().Should().BeCloseTo(System.DateTime.UtcNow);
        }

        [Fact]
        public void TestConvertUtcToUk()
        {
            //System.DateTime utcNow = System.DateTime.UtcNow;

            //IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            //System.DateTime dateTest = dateTimeProvider.ConvertUtcToUk(utcNow);

            //// https://stackoverflow.com/questions/4034923/how-to-represent-the-current-uk-time
            //TimeZoneInfo britishZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            //System.DateTime dateBaseline = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.Utc, britishZone);

            //dateTest.Should().Be(dateBaseline);
        }

        [Fact]
        public void TestConvertInvalidDateTimeToUk()
        {
            System.DateTime dateTime = new System.DateTime(2018, 1, 14, 12, 0, 0, DateTimeKind.Local);

            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            Action dateTimeTest = () => dateTimeProvider.ConvertUtcToUk(dateTime);
            dateTimeTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestConvertOpaToLocalDateTime()
        {
            const string opaDateTime = "2018-08-01 00:00:00";
            System.DateTime target = new System.DateTime(2018, 8, 1);

            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            System.DateTime dateTest = dateTimeProvider.ConvertOpaToDateTime(opaDateTime);

            dateTest.Should().Be(target);
        }
    }
}
