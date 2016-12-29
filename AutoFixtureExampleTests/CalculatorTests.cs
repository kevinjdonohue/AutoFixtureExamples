using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
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

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 2, 2)]
        [InlineData(-5, 1, -4)]
        public void Add_ShouldCalculateResult_GivenInlineData(int firstNumber, int secondNumber, int expectedResult)
        {
            //arrange
            Calculator sut = new Calculator();

            //act
            sut.Add(firstNumber);
            sut.Add(secondNumber);

            //assert
            sut.Value.Should().Be(expectedResult);
        }

        [Theory]
        [AutoData]
        public void Add_ShouldCalculateResult_GivenAutoData(Calculator sut, int firstNumber, int secondNumber)
        {
            //arrange

            //act
            sut.Add(firstNumber);
            sut.Add(secondNumber);

            //assert
            sut.Value.Should().Be(firstNumber + secondNumber);
        }

        //NOTE:  The Calculator sut is being passed as the last parameter because as the first parameter 
        //       it was interfering with the [InlineAutoData] without parameters
        [Theory]
        [InlineAutoData]  //two positive numbers
        [InlineAutoData(0)]  //zero and positive number
        [InlineAutoData(-5)]  //negative and positive number
        public void Add_ShouldCalculateResult_GivenInlineAutoData(int firstNumber, int secondNumber, Calculator sut)
        {
            //arrange

            //act
            sut.Add(firstNumber);
            sut.Add(secondNumber);

            //assert
            sut.Value.Should().Be(firstNumber + secondNumber);
        }
    }
}
