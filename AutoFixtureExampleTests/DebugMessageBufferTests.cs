using System;
using AutoFixtureExample;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class DebugMessageBufferTests : IDisposable
    {
        private Fixture _fixture;

        public DebugMessageBufferTests()
        {
            _fixture = new Fixture();
        }

        public void Dispose()
        {
            _fixture = null;
        }

        [Fact]
        public void WriteMessages_ShouldOutputTenMessages()
        {
            //arrange
            DebugMessageBuffer sut = new DebugMessageBuffer();
            _fixture.AddManyTo(sut.Messages, 10);

            //act
            sut.WriteMessages();
        }

        [Fact]
        public void WriteMessages_ShouldOutputThreeRandomMessages()
        {
            //arrange
            DebugMessageBuffer sut = new DebugMessageBuffer();
            Random random = new Random();
            _fixture.AddManyTo(sut.Messages, () => random.Next(11).ToString());

            //act
            sut.WriteMessages();
        }
    }
}