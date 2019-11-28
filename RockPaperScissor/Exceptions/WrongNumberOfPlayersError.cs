namespace RockPaperScissors.Exceptions
{
    public class WrongNumberOfPlayersError : AppLogicException
    {
        public WrongNumberOfPlayersError(string message): base(message)
        {

        }
    }
}
