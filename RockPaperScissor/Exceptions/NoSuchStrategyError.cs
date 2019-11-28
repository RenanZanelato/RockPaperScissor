namespace RockPaperScissors.Exceptions
{
    public class NoSuchStrategyError : AppLogicException
    {
        public NoSuchStrategyError(string message): base(message)
        {

        }
    }
}
