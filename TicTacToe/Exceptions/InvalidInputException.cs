using System;

namespace TicTacToe.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string input)
            : base(String.Format("Invalid Input: {0}", input))
        {

        }
    }
}