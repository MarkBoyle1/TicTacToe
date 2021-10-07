using System;

namespace TicTacToe
{
    public class UserInput : IUserInput
    {
        public string GetCoordinates()
        {
            return Console.ReadLine();
        }
    }
}