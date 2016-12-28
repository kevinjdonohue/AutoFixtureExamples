using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class NameJoinerTests
    {
        [Fact]
        public void BasicString()
        {
            //arrange
            NameJoiner sut = new NameJoiner();
            Fixture fixture = new Fixture();
            string firstName = fixture.Create<string>("first_");    
            string lastName = fixture.Create<string>("last_");
            string expectedFullName = $"{firstName} {lastName}";

            //act
            string result = sut.Join(firstName, lastName);  

            //assert            
            result.Should().Be(expectedFullName);
        }
    }
}
