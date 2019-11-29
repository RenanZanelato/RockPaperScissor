using FluentAssertions;
using NUnit.Framework;
using RockPaperScissors.Actions;
using RockPaperScissors.Entities;
using RockPaperScissors.Exceptions;
using System;
using System.Collections.Generic;
using RockPaperScissors.Interfaces;

namespace RockPaperScissors.Test.Actions
{
    [TestFixture]
    public class RulesTest
    {
        private IRules Rules;

        [SetUp]
        public void Setup()
        {
            this.Rules = new Rules();
        }

        [Test]
        public void ShouldThrowWrongNumberOfPlayersErrorException()
        {
            IList<Player> Players = new List<Player>();
            Player Armando = new Player("Armando", Config.Chooses.Rock);
            Player Dave = new Player("Dave", Config.Chooses.Rock);
            Player JoaoZinho = new Player("JoaoZinho", Config.Chooses.Scissor);
            Players.Add(Armando);
            Players.Add(Dave);
            Players.Add(JoaoZinho);

            Action comparison = () =>
            {
                this.Rules.CalculatePlayerWinner(Players);
            };

            comparison.Should().Throw<WrongNumberOfPlayersError>().WithMessage("Invalid number off Players, Max Players: 2");
        }

        [Test]
        public void ShouldThrowNoSuchStrategyErrorException()
        {
            IList<Player> Players = new List<Player>();
            Player Armando = new Player("Armando", Config.Chooses.Rock);
            Player Dave = new Player("Dave", 'D');

            Players.Add(Armando);
            Players.Add(Dave);

            Action comparison = () =>
            {
                this.Rules.CalculatePlayerWinner(Players);
            };

            comparison.Should().Throw<NoSuchStrategyError>(string.Format("Invalid Move {0} use only {1}", Dave.Move, string.Join(",", Rules.ValidPlays)));
        }

        [Test]
        public void ShouldPlayerOneWinWhenGameTies()
        {
            IList<Player> Players = new List<Player>();
            Player Armando = new Player("Armando", Config.Chooses.Rock);
            Player Dave = new Player("Dave", Config.Chooses.Rock);

            Players.Add(Armando);
            Players.Add(Dave);

            Player Winner = this.Rules.CalculatePlayerWinner(Players);
            Winner.Should().Be(Armando);
        }

        [Test]
        public void ShouldPaperWinRock()
        {
            IList<Player> Players = new List<Player>();
            Player Armando = new Player("Armando", Config.Chooses.Rock);
            Player Dave = new Player("Dave", Config.Chooses.Paper);

            Players.Add(Armando);
            Players.Add(Dave);

            Player Winner = this.Rules.CalculatePlayerWinner(Players);
            Winner.Should().Be(Dave);
        }

        [Test]
        public void ShouldScissorrWinPaper()
        {
            IList<Player> Players = new List<Player>();
            Player Armando = new Player("Armando", Config.Chooses.Paper);
            Player Dave = new Player("Dave", Config.Chooses.Scissor);

            Players.Add(Armando);
            Players.Add(Dave);

            Player Winner = this.Rules.CalculatePlayerWinner(Players);
            Winner.Should().Be(Dave);
        }

        [Test]
        public void ShouldRockWinScissor()
        {
            IList<Player> Players = new List<Player>();
            Player Armando = new Player("Armando", Config.Chooses.Scissor);
            Player Dave = new Player("Dave", Config.Chooses.Rock);

            Players.Add(Armando);
            Players.Add(Dave);

            Player Winner = this.Rules.CalculatePlayerWinner(Players);
            Winner.Should().Be(Dave);
        }

    }
}
