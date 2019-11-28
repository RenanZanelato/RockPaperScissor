using RockPaperScissors.Entities;
using System.Collections.Generic;

namespace RockPaperScissors.Interfaces
{
    public interface IRules
    {
         Player CalculatePlayerWinner(IList<Player> Players);
    }
}
