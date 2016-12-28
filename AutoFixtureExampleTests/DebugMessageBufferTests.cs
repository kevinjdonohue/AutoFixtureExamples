using System;
using System.IO;
using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class DebugMessageBufferTests
    {
        [Fact]
        public void WriteMessages_ShouldOutputTenMessages()
        {
            //arrange
            Fixture fixture = new Fixture();
            DebugMessageBuffer sut = new DebugMessageBuffer();
            fixture.AddManyTo(sut.Messages, 10);

            //act
            sut.WriteMessages();
        }

        [Fact]
        public void WriteMessages_ShouldOutputThreeRandomMessages()
        {
            //arrange
            Fixture fixture = new Fixture();
            DebugMessageBuffer sut = new DebugMessageBuffer();
            Random random = new Random();
            fixture.AddManyTo(sut.Messages, () => random.Next(11).ToString());

            //act
            sut.WriteMessages();
        }
    }
}