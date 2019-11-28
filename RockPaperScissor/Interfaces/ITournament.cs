using RockPaperScissors.Entities;
using System.Collections.Generic;

namespace RockPaperScissors.Interfaces
{
    public interface ITournament
    {
        Player RpsTournamentWinner(dynamic TournamentObject);

        Player RpsGameWinner(IList<Player> Players);
    }
}
