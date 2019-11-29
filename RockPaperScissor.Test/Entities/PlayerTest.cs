using FluentAssertions;
using NUnit.Framework;
using RockPaperScissors.Entities;
using System;

namespace RockPaperScissors.Test.Entities
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void ShouldMoveBeUppercase()
        {
          
            Player Armando = new Player("Armando", 's');
            Armando.Move.Should().Be('S');
        }
    }
}