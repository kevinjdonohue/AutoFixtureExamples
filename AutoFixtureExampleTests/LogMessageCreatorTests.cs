using System;
using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class LogMessageCreatorTests
    {
        [Fact]
        public void Create_ShouldReturnAValidLogMessage()
        {
            //arrange
            Fixture fixture = new Fixture();
            DateTime expectedDateTime = fixture.Create<DateTime>();

            //act
            LogMessage actualLogMessage = LogMessageCreator.Create(fixture.Create<string>(), expectedDateTime);

            //assert
            actualLogMessage.Year.Should().Be(expectedDateTime.Year);
        }
    }
}