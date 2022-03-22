using Xunit;
using AutoFixture;

namespace DemoCode.Tests
{
    public class NumberDemos
    {
        [Fact]
        public void Ints()
        {
            // Arrange
            var sut = new IntCalculator();
            var fixture = new Fixture();
            // var anonymousNumber = fixture.Create<int>();

            // Act
            sut.Subtract(fixture.Create<int>());

            // Assert
            Assert.True(sut.Value < 0);
        }

        [Fact]
        public void Decimals()
        {
            var fixtue = new Fixture();
            var sut = new DecimalCalculator();

            decimal num = fixtue.Create<decimal>();

            sut.Add(num);

            Assert.Equal(num, sut.Value);
        }
    }
}