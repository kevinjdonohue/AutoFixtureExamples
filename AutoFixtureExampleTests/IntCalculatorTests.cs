using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class IntCalculatorTests
    {
        [Fact]
        public void Ints()
        {
            //arrange
            IntCalculator sut = new IntCalculator();
            Fixture fixture = new Fixture();
            int num = fixture.Create<int>();

            //act
            sut.Add(num);

            //assert
            sut.Value.Should().Be(num);
        }
    }
}