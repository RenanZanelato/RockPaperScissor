using RockPaperScissors.Actions;
using RockPaperScissors.Config;
using RockPaperScissors.Entities;
using RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Tournament \n");

            try
            {
                IList<Object> TournamentObject = SetKeysTournament();

                StartGame(TournamentObject);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

        static IList<Object> SetKeysTournament()
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

            IList<Object> TournamentObject = new List<Object>();
            TournamentObject.Add(GroupPlayers);
            TournamentObject.Add(GroupPlayers2);

            return TournamentObject;
        }

        static void StartGame(IList<Object> TournamentObject)
        {

            IRules Rules = new Rules();
            ITournament RockPapperTornament = new Tournament(Rules);
            Player Winner = RockPapperTornament.RpsTournamentWinner(TournamentObject);

            Console.WriteLine(string.Format("The Winner for Tournament is {0}", Winner.Name));
        }
    }
}
