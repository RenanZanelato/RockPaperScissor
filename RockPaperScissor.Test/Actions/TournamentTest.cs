using NUnit.Framework;
using RockPaperScissors.Actions;
using RockPaperScissors.Entities;
using System;
using System.Collections.Generic;
using RockPaperScissors.Interfaces;
using RockPaperScissors.Config;
using FluentAssertions;

namespace RockPaperScissors.Test.Actions
{
    [TestFixture]
    public class TournamentTest
    {
        private ITournament Tournament;

        [SetUp]
        public void Setup()
        {
            IRules Rules = new Rules();
            this.Tournament = new Tournament(Rules);
        }

        [Test]
        public void ShouldCalculateTournamentWinner()
        {
            Player Armando = new Player("Armando", Chooses.Paper);
            Player Dave = new Player("Dave", Chooses.Scissor);

            IList<Player> Players1 = new List<Player>();
            Players1.Add(Armando);
            Players1.Add(Dave);

            Player Richard = new Player("Richard", Chooses.Rock);
            Player Michael = new Player("Michael", Chooses.Scissor);
            IList<Player> Players2 = new List<Player>();
            Players2.Add(Richard);
            Players2.Add(Michael);

            Player Allen = new Player("Allen", Chooses.Scissor);
            Player Omer = new Player("Omer", Chooses.Paper);
            IList<Player> Players3 = new List<Player>();
            Players3.Add(Allen);
            Players3.Add(Omer);

            Player DavidE = new Player("David E", Chooses.Rock);
            Player RichardX = new Player("Richard X", Chooses.Paper);
            IList<Player> Players4 = new List<Player>();
            Players4.Add(DavidE);
            Players4.Add(RichardX);

            IList<Object> GroupPlayers = new List<Object>();
            GroupPlayers.Add(Players1);
            GroupPlayers.Add(Players2);

            IList<Object> GroupPlayers2 = new List<Object>();
            GroupPlayers2.Add(Players3);
            GroupPlayers2.Add(Players4);

            IList<Object> TournamentMock = new List<Object>();
            TournamentMock.Add(GroupPlayers);
            TournamentMock.Add(GroupPlayers2);

            Player Winner = this.Tournament.RpsTournamentWinner(TournamentMock);
            Winner.Should().Be(Richard);
        }

        [Test]
        public void ShouldCalculateWinner()
        {
            Player Armando = new Player("Armando", Chooses.Paper);
            Player Dave = new Player("Dave", Chooses.Scissor);

            IList<Player> PlayersMock = new List<Player>();
            PlayersMock.Add(Armando);
            PlayersMock.Add(Dave);

            Player Winner = this.Tournament.RpsGameWinner(PlayersMock);
            Winner.Should().Be(Dave);
        }
    }
}
