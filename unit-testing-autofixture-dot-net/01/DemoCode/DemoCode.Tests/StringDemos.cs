using System;
using Xunit;
using AutoFixture;

namespace DemoCode.Tests
{
    public class StringDemos
    {
        [Fact]
        public void BasicStrings()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new NameJoiner();

            // After install AutoFixture.Seed.Extensions on Nugget
            //var firstName = fixture.Create<string>();
            //var lastName = fixture.Create<string>();

            var firstName = fixture.Create("First_");
            var lastName = fixture.Create("Last_");

            // Act
            var result = sut.Join(firstName, lastName);

            // Assert
            Assert.Equal(firstName + ' ' + lastName, result);
        }

        [Fact]
        public void Chars()
        {
            // Arrange
            var fixture = new Fixture();

            var anonChar = fixture.Create<char>();

            // Act, Assert...
        }
    }
}
