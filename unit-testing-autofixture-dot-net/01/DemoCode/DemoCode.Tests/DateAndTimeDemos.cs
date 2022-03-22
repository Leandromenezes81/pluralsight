using AutoFixture;
using System;
using Xunit;

namespace DemoCode.Tests
{
    public class DateAndTimeDemos
    {
        [Fact]
        public void DateTimes()
        {
            // Arrange
            var fixture = new Fixture();

            // DateTime logTime = new DateTime(2022, 3, 17);
            DateTime logTime = fixture.Create<DateTime>();

            // Act
            LogMessage result = LogMessageCreator.Create(fixture.Create<string>(), logTime);

            // Assert
            Assert.Equal(logTime.Year, result.Year);
        }

        [Fact]
        public void TimeSpans()
        {
            var fixture = new Fixture();

            TimeSpan timeSpan = fixture.Create<TimeSpan>();
        }
    }
}
