using System;

namespace RockPaperScissors.Exceptions
{
    public class AppLogicException : Exception
    {
        public AppLogicException(string message): base(message)
        {

        }
    }
}
