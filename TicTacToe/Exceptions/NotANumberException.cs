using System;

namespace TicTacToe.Exceptions
{
    public class NotANumberException : Exception
    {
        public NotANumberException(string input)
            : base(String.Format("Invalid input. Not A Number: {0}", input))
        {

        }
    }
}