using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class EmailMessageBufferTests
    {
        [Fact]
        public void Add_ShouldAddOneMessageToTheEmailsCollection_ManualSetup()
        {
            //arrange
            EmailMessageBuffer sut = new EmailMessageBuffer();
            EmailMessage expectedEmailMessage = new EmailMessage("me@me.com", "message body", false)
            {
                Subject = "hi"
            };

            //act
            sut.Add(expectedEmailMessage);

            //assert
            sut.Emails.Count.Should().Be(1);
            EmailMessage actualEmailMessage = sut.Emails[0];
            actualEmailMessage.ShouldBeEquivalentTo(expectedEmailMessage);
        }

        [Fact]
        public void Add_ShouldAddOneMessageToTheEmailsCollection_AutoCreation()
        {
            //arrange
            Fixture fixture = new Fixture();
            EmailMessageBuffer sut = new EmailMessageBuffer();
            EmailMessage expectedEmailMessage = fixture.Create<EmailMessage>();

            //act
            sut.Add(expectedEmailMessage);

            //assert
            sut.Emails.Count.Should().Be(1);
            EmailMessage actualEmailMessage = sut.Emails[0];
            actualEmailMessage.ShouldBeEquivalentTo(expectedEmailMessage);
        }
    }
}