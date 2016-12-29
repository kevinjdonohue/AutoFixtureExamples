using System;
using AutoFixtureExample;
using FluentAssertions;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class EmailMessageBufferTests : IDisposable
    {
        private Fixture _fixture;

        public EmailMessageBufferTests()
        {
            _fixture = new Fixture();
        }

        public void Dispose()
        {
            _fixture = null;
        }

        [Fact]
        public void Add_ShouldAddOneMessageToTheBuffer_ManualSetup()
        {
            //arrange
            Mock<IEmailGateway> mockGateway = new Mock<IEmailGateway>();
            EmailMessageBuffer sut = new EmailMessageBuffer(mockGateway.Object);
            EmailMessage expectedEmailMessage = _fixture.Create<EmailMessage>();

            //act
            sut.Add(expectedEmailMessage);

            //assert
            sut.Emails.Count.Should().Be(1);
            EmailMessage actualEmailMessage = sut.Emails[0];
            actualEmailMessage.ShouldBeEquivalentTo(expectedEmailMessage);
        }

        [Fact]
        public void Add_ShouldAddOneMessageToTheBuffer_AutoCreation()
        {
            //arrange
            Mock<IEmailGateway> mockGateway = new Mock<IEmailGateway>();
            EmailMessageBuffer sut = new EmailMessageBuffer(mockGateway.Object);
            EmailMessage expectedEmailMessage = _fixture.Create<EmailMessage>();

            //act
            sut.Add(expectedEmailMessage);

            //assert
            sut.Emails.Count.Should().Be(1);
            EmailMessage actualEmailMessage = sut.Emails[0];
            actualEmailMessage.ShouldBeEquivalentTo(expectedEmailMessage);
        }

        [Fact]
        public void SendAll_ShouldSendOneMessage_ManualSetup()
        {
            //arrange
            Mock<IEmailGateway> mockGateway = new Mock<IEmailGateway>();
            EmailMessageBuffer sut = new EmailMessageBuffer(mockGateway.Object);
            sut.Add(_fixture.Create<EmailMessage>());

            //act
            sut.SendAll();

            //assert
            sut.UnsentMessagesCount.Should().Be(0);
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

        [Fact]
        public void SendAll_ShouldSendThreeMessages_AutoMoqAndFreeze()
        {
            //arrange
            _fixture.Customize(new AutoMoqCustomization());
            Mock<IEmailGateway> mockGateway = _fixture.Freeze<Mock<IEmailGateway>>();
            EmailMessageBuffer sut = _fixture.Create<EmailMessageBuffer>();

            //act
            sut.SendAll();

            //assert
            sut.UnsentMessagesCount.Should().Be(0);
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Exactly(3));
        }

        [Fact]
        public void SendLimited_ShouldSendTwoMessages_ManualSetup()
        {
            //arrange
            Mock<IEmailGateway> mockGateway = new Mock<IEmailGateway>();
            EmailMessageBuffer sut = new EmailMessageBuffer(mockGateway.Object);
            sut.Add(_fixture.Create<EmailMessage>());
            sut.Add(_fixture.Create<EmailMessage>());
            sut.Add(_fixture.Create<EmailMessage>());

            //act
            sut.SendLimited(2);

            //assert
            sut.UnsentMessagesCount.Should().Be(1);
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Exactly(2));
        }
    }
}