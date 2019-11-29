using RockPaperScissors.Entities;
using RockPaperScissors.Exceptions;
using RockPaperScissors.Interfaces;
using System.Collections.Generic;

namespace RockPaperScissors.Actions
{
    public class Rules : IRules
    {
        private IList<char> ValidPlays;

        public Rules()
        {
            this.ValidPlays = new List<char>();
            this.ValidPlays.Add(Config.Chooses.Paper);
            this.ValidPlays.Add(Config.Chooses.Rock);
            this.ValidPlays.Add(Config.Chooses.Scissor);
        }

        public Player CalculatePlayerWinner(IList<Player> Players)
        {

            this.ValidateMatch(Players);

            Player Player1 = Players[0];
            Player Player2 = Players[1];


            if (IsGameTied(Players[0], Players[1]))
                return Player1;

            if (Player1.Move == Config.Chooses.Rock && Player2.Move == Config.Chooses.Paper)
                return Player2;

            if (Player1.Move == Config.Chooses.Paper && Player2.Move == Config.Chooses.Scissor)
                return Player2;

            if (Player1.Move == Config.Chooses.Scissor && Player2.Move == Config.Chooses.Rock)
                return Player2;

            return Player1;
        }

        private void ValidateMatch(IList<Player> Players)
        {
            this.ValidatePlayersNumber(Players);
            this.ValidatePlayerMove(Players[0]);
            this.ValidatePlayerMove(Players[1]);
        }

        private bool ValidatePlayersNumber(IList<Player> Players)
        {
            if (Players.Count != Config.Players.MAX_PLAYERS)
            {
                throw new WrongNumberOfPlayersError(string.Format("Invalid number off Players, Max Players: {0}", Config.Players.MAX_PLAYERS));
            }
            return true;
        }
        private bool ValidatePlayerMove(Player Player)
        {
            if (!this.ValidPlays.Contains(Player.Move))
            {
                throw new NoSuchStrategyError(string.Format("Invalid Move {0} use only {1}", Player.Move, string.Join(",", this.ValidPlays)));
            }
            return true;
        }

        private bool IsGameTied(Player Player1, Player Player2)
        {
            return Player1.Move == Player2.Move;
        }
    }
}
