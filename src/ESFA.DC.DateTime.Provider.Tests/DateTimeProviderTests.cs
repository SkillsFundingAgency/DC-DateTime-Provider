using System;
using ESFA.DC.DateTimeProvider.Interface;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.DateTimeProvider.Tests
{
    public sealed class DateTimeProviderTests
    {
        [Fact]
        public void TestGetNowUtc()
        {
            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            dateTimeProvider.GetNowUtc().Should().BeCloseTo(DateTime.UtcNow);
        }

        [Fact]
        public void TestConvertUtcToUk()
        {
            DateTime utcNow = DateTime.UtcNow;

            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            DateTime dateTest = dateTimeProvider.ConvertUtcToUk(utcNow);

            // https://stackoverflow.com/questions/4034923/how-to-represent-the-current-uk-time
            TimeZoneInfo britishZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            DateTime dateBaseline = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.Utc, britishZone);

            dateTest.Should().Be(dateBaseline);
        }

        [Fact]
        public void TestConvertInvalidDateTimeToUk()
        {
            DateTime dateTime = new DateTime(2018, 1, 14, 12, 0, 0, DateTimeKind.Local);

            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            Action dateTimeTest = () => dateTimeProvider.ConvertUtcToUk(dateTime);
            dateTimeTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestConvertUkToUtcWinter()
        {
            const string ilrFilenameDateTime = "20171107-113456";

            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            DateTime dateTime = dateTimeProvider.ConvertUkToUtc(ilrFilenameDateTime);

            dateTime.Year.Should().Be(2017);
            dateTime.Month.Should().Be(11);
            dateTime.Day.Should().Be(7);

            dateTime.Hour.Should().Be(11);
            dateTime.Minute.Should().Be(34);
            dateTime.Second.Should().Be(56);
        }

        [Fact]
        public void TestConvertUkToUtcSummer()
        {
            const string ilrFilenameDateTime = "20170528-113456";

            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            DateTime dateTime = dateTimeProvider.ConvertUkToUtc(ilrFilenameDateTime);

            dateTime.Year.Should().Be(2017);
            dateTime.Month.Should().Be(5);
            dateTime.Day.Should().Be(28);

            dateTime.Hour.Should().Be(10);
            dateTime.Minute.Should().Be(34);
            dateTime.Second.Should().Be(56);
        }
    }
}
