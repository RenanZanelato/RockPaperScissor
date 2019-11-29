using RockPaperScissors.Entities;
using RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Actions
{
    public class Tournament : ITournament
    {
        private readonly IRules Rules;
        private int Round = 0;

        public Tournament(IRules Rules)
        {
            this.Rules = Rules;
        }

        public Player RpsTournamentWinner(dynamic TournamentObject)
        {
            IList <Player> tournamentPlayers = new List<Player>();

            foreach(var listOrPlayer in TournamentObject)
            {
                tournamentPlayers.Add( (listOrPlayer is Player) ? listOrPlayer : this.RpsTournamentWinner(listOrPlayer)) ;
            }
                
            return this.RpsGameWinner(tournamentPlayers);
        }

        public Player RpsGameWinner(IList<Player> Players)
        {
            this.Round += 1;

            Console.WriteLine(string.Format("Round {0}\r\n", this.Round));
         
            Console.WriteLine(string.Format("Player {0} Move {1} vs Player {2} Move {3}\r\n", Players[0].Name, Players[0].Move, Players[1].Name, Players[1].Move));
            
            Player Winner = this.Rules.CalculatePlayerWinner(Players);
            
            Console.WriteLine(string.Format("Winner {0}\r\n", Winner.Name));
            Console.WriteLine("\r\n");

            return Winner;
        }
    }
}
