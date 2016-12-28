using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Traditional()
        {
            //arrange
            Calculator sut = new Calculator();

            //act
            sut.Subtract(1);

            //assert
            sut.Value.Should().BeLessThan(0);
        }

        [Fact]
        public void Manual_Anonymous_Data()
        {
            //arrange
            Calculator sut = new Calculator();
            int anonymousNumber = 394;

            //act
            sut.Subtract(anonymousNumber);

            //assert
            sut.Value.Should().BeLessThan(0);
        }

        [Fact]
        public void AutoFixture_Anonymous_Data()
        {
            //arrange
            Calculator sut = new Calculator();
            Fixture fixture = new Fixture();

            //act
            sut.Subtract(fixture.Create<int>());

            //assert
            sut.Value.Should().BeLessThan(0);
        }
    }
}
