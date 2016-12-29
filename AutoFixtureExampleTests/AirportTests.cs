using System;
using AutoFixtureExample;
using AutoFixtureExampleTests.SpecimenBuilders;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class AirportTests : IDisposable
    {
        private Fixture _fixture;

        public AirportTests()
        {
            _fixture = new Fixture();
        }

        public void Dispose()
        {
            _fixture = null;
        }

        [Fact]
        public void Example_BuildingWithACustomizedPipeline()
        {
            //arrange
            _fixture.Customizations.Add(new AirportCodeSpecimenBuilder());
            Airport airport = _fixture.Create<Airport>();

            //assert
            airport.AirportCode.Should().BeOneOf("AAA", "BBB");
        }
    }
}