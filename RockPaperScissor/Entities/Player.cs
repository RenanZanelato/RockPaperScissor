using System;

namespace RockPaperScissors.Entities
{
    public class Player
    {
        public string Name { get; }
        public char Move { get; }

        public Player(String Name, char Move)
        {
            this.Move = Char.ToUpper(Move);
            this.Name = Name;
        }
    }
}