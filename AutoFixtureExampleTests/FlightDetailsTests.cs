using System;
using System.Collections.Generic;
using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class FlightDetailsTests : IDisposable
    {
        private Fixture _fixture;

        public FlightDetailsTests()
        {
            _fixture = new Fixture();
        }

        public void Dispose()
        {
            _fixture = null;
        }

        [Fact]
        public void Example_InjectingAString()
        {
            //arrange
            string expectedValue = "LHR";
            _fixture.Inject(expectedValue);
            FlightDetails flightDetails = _fixture.Create<FlightDetails>();

            //assert
            flightDetails.AirlineName.Should().Be(expectedValue);
            flightDetails.ArrivalAirportCode.Should().Be(expectedValue);
            flightDetails.DepartureAirportCode.Should().Be(expectedValue);
        }

        [Fact]
        public void Example_InjectingAnObject()
        {
            //arrange
            _fixture.Inject(new FlightDetails
            {
                AirlineName = "Awesome Aero",
                ArrivalAirportCode = "LHR",
                DepartureAirportCode = "PER",
                FlightDuration = TimeSpan.FromHours(10)
            });
            FlightDetails flight1 = _fixture.Create<FlightDetails>();
            FlightDetails flight2 = _fixture.Create<FlightDetails>();

            //assert
            flight1.ShouldBeEquivalentTo(flight2);
        }

        [Fact]
        public void Example_BuildingWithoutSomeProperties()
        {
            //arrange
            FlightDetails flightDetails = _fixture.Build<FlightDetails>()
                .Without(fd => fd.ArrivalAirportCode)
                .Without(fd => fd.DepartureAirportCode)
                .Create();

            //assert
            flightDetails.ArrivalAirportCode.Should().BeNull();
            flightDetails.DepartureAirportCode.Should().BeNull();
        }

        [Fact]
        public void Example_BuildingWithCustomProperties()
        {
            //arrange
            FlightDetails flightDetails = _fixture.Build<FlightDetails>()
                .With(fd => fd.ArrivalAirportCode, "LAX")
                .With(fd => fd.DepartureAirportCode, "LHR")
                .Create();

            //assert
            flightDetails.ArrivalAirportCode.Should().Be("LAX");
            flightDetails.DepartureAirportCode.Should().Be("LHR");
        }

        [Fact]
        public void Example_BuildingWithCustomPropertiesAndActions()
        {
            //arrange
            FlightDetails flightDetails = _fixture.Build<FlightDetails>()
                .With(fd => fd.ArrivalAirportCode, "LAX")
                .With(fd => fd.DepartureAirportCode, "LHR")
                .Without(fd => fd.MealOptions)
                .Do(fd => fd.MealOptions.Add("Chicken"))
                .Do(fd => fd.MealOptions.Add("Fish"))
                .Create();
            List<string> expectedMealOptions = new List<string>()
            {
                "Chicken",
                "Fish"
            };

            //assert
            flightDetails.ArrivalAirportCode.Should().Be("LAX");
            flightDetails.DepartureAirportCode.Should().Be("LHR");
            flightDetails.MealOptions.Should().HaveCount(2);
            flightDetails.MealOptions.ShouldBeEquivalentTo(expectedMealOptions, options => options.WithStrictOrdering());
        }
    }
}